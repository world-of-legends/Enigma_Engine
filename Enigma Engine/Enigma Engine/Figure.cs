using Stride.Graphics;
using Stride.Graphics.GeometricPrimitives;
using System;
using System.Collections.Generic;
using Stride.Rendering;
using Stride.Core.Mathematics;
using Buffer = Stride.Graphics.Buffer;

namespace Enigma
{
    public class Figure
    {
        private Renderer renderer => RuntimeLevel.renderer;
        //its a shit-code dont look at it

        public void DrawCube()
        {
            GeometricPrimitive cube = GeometricPrimitive.Cube.New(renderer.gd);
            cube.Draw(new GraphicsContext(renderer.gd), new EffectInstance(
                new Effect(renderer.gd, new Stride.Shaders.EffectBytecode())));
        }

        /// <summary>
        /// Now its just copypaste from docs of Stride. I learn low-level graphics API
        /// </summary>
        /// <param name="vertexCount"></param>
        public void CustomDraw(int vertexCount)
        {
            // Create a vertex layout with position and texture coordinate
            VertexDeclaration layout = new VertexDeclaration(VertexElement.Position<Vector3>(), VertexElement.TextureCoordinate<Vector2>());

            // Create the vertex buffer from an array of vertices
            VertexPositionTexture[] vertices = new VertexPositionTexture[vertexCount];
            Buffer<VertexPositionTexture> vertexBuffer = Buffer.Vertex.New(renderer.gd, vertices);

            // Create a vertex buffer binding
            VertexBufferBinding vertexBufferBinding = new VertexBufferBinding(vertexBuffer, layout, vertexCount);

            PipelineStateDescription pipelineStateDescription = new PipelineStateDescription();
            PipelineState pipelineState = PipelineState.New(renderer.gd, ref pipelineStateDescription);
            pipelineStateDescription.InputElements = new VertexBufferBinding[] { vertexBufferBinding }.CreateInputElements();
            pipelineStateDescription.PrimitiveType = PrimitiveType.TriangleStrip;

            // Create and set a PipelineState object
            CommandList commandList = renderer.cl;
            commandList.SetPipelineState(pipelineState);

            // Bind the vertex buffer to the pipeline
            commandList.SetVertexBuffer(0, vertexBuffer, 0, vertexBufferBinding.Stride);

            // Draw the vertices
            commandList.Draw(vertexCount);
        }
    }
}
