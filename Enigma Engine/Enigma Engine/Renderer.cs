using Stride.Graphics;
using System;
using System.Collections.Generic;
using Assimp;
using Stride.Core.Mathematics;
using Stride.Rendering.Materials;
using Stride.Rendering.Materials.ComputeColors;

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

        public void LoadModel(string modelPath, ref Stride.Rendering.Model model)
        {
            Scene mdl = assimp.ImportFile(modelPath);
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

                        // Create a material (eg with red diffuse color).
                        /*var materialDescription = new MaterialDescriptor
                        {
                            Attributes =
                            {
                                DiffuseModel = new MaterialDiffuseLambertModelFeature(),
                                Diffuse = new MaterialDiffuseMapFeature(new ComputeColor 
                                { Key = MaterialKeys.DiffuseValue })
                            }
                        };
                        var material = Material.New(gd, materialDescription);
                        material.Parameters[0].Set(MaterialKeys.DiffuseValue, Color.Red);
                        model.Materials.Add(0, material);*/
                    }
                }
            }
        }

        public static Vector3 ConvertVector(Vector3D vec) => new Vector3(vec.X, vec.Y, vec.Z);
    }
}
