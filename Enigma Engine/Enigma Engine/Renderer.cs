using Stride.Graphics;
using System;
using System.Collections.Generic;
using Assimp;
using Stride.Core.Mathematics;
using Stride.Rendering.Materials;
using Stride.Rendering.Materials.ComputeColors;
using Stride.Rendering.Lights;

namespace Enigma
{
    public class Renderer
    {
        public GraphicsDevice gd;
        public CommandList cl;
        private AssimpContext assimp;

        public Renderer(GraphicsDevice device)
        {
            gd = device;
            cl = CommandList.New(gd);
            assimp = new AssimpContext();
        }

        public void LoadModel(string modelPath, out Stride.Engine.Entity entity)
        {
            Scene mdl = assimp.ImportFile(modelPath);
            Stride.Rendering.Model model = new Stride.Rendering.Model();
            entity = new Stride.Engine.Entity();
            if (mdl.HasMeshes)
            {
                foreach (Mesh mesh in mdl.Meshes)
                {
                    if (mesh.HasVertices)
                    {
                        VertexPositionTexture[] vertices = new VertexPositionTexture[mesh.VertexCount];
                        for (int i = 0; i < mesh.VertexCount; i++) // copy vertices from model to array
                            vertices[i].Position = ConvertVector(mesh.Vertices[i]);
                        Buffer<VertexPositionTexture> vertexBuffer = Stride.Graphics.Buffer.Vertex.New(gd, vertices,
                                                     GraphicsResourceUsage.Dynamic);
                        int[] indices = mesh.GetIndices();
                        Buffer<int> indexBuffer = Stride.Graphics.Buffer.Index.New(gd, indices);
                        Stride.Rendering.Mesh customMesh = new Stride.Rendering.Mesh
                        {
                            Draw = new Stride.Rendering.MeshDraw
                            {
                                /* Vertex buffer and index buffer setup */
                                PrimitiveType = Stride.Graphics.PrimitiveType.LineStrip,
                                DrawCount = indices.Length,
                                IndexBuffer = new IndexBufferBinding(indexBuffer, true, indices.Length),
                                VertexBuffers = new[] { new VertexBufferBinding(vertexBuffer,
                                  VertexPositionTexture.Layout, vertexBuffer.ElementCount) },
                            }
                        };
                        // add the mesh to the model
                        model.Meshes.Add(customMesh);
                    }
                }
            }
            if (mdl.HasAnimations)
            {
                //pass
            }
            if (mdl.HasCameras)
            {
                foreach (Camera camera in mdl.Cameras)
                {
                }
            }
            if (mdl.HasLights)
            {
                foreach (Light light in mdl.Lights)
                {
                    switch (light.LightType)
                    {
                        case LightSourceType.Undefined:
                            break;
                        case LightSourceType.Directional:
                            break;
                        case LightSourceType.Point:
                            break;
                        case LightSourceType.Spot:
                            break;
                        case LightSourceType.Ambient:
                            break;
                        case LightSourceType.Area:
                            break;
                    }
                }
            }
            if (mdl.HasMaterials)
            {
                foreach (Material mat in mdl.Materials)
                {
                    Color4 diffuse = ConvertColor(mat.ColorDiffuse), ambient = ConvertColor(mat.ColorAmbient);
                    var materialDescription = new MaterialDescriptor
                    {
                        Attributes =
                            {
                                DiffuseModel = new MaterialDiffuseLambertModelFeature(),
                                Diffuse = new MaterialDiffuseMapFeature(new ComputeColor
                                { Key = MaterialKeys.DiffuseValue, Value = diffuse })
                            }
                    };
                    Stride.Rendering.Material material = Stride.Rendering.Material.New(gd, materialDescription);
                    model.Materials.Insert(0, material);
                }
            }
            if (mdl.HasTextures)
            {
                //pass
            }
            entity.Add(new Stride.Engine.ModelComponent(model));
        }

        public static Vector3 ConvertVector(Vector3D vec) => new Vector3(vec.X, vec.Y, vec.Z);
        public static Color4 ConvertColor(Color4D color) => new Color4(color.R, color.G, color.B, color.A);
    }
}
