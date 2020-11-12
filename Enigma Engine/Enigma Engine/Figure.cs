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
        //its a shit-code dont look at it

        public void DrawCube()
        {
            GeometricPrimitive cube = GeometricPrimitive.Cube.New(Level.Graphics);
            cube.Draw(new GraphicsContext(Level.Graphics), new EffectInstance(
                new Effect(Level.Graphics, new Stride.Shaders.EffectBytecode())));
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
            var vertices = new VertexPositionTexture[vertexCount];
            var vertexBuffer = Buffer.Vertex.New(Level.Graphics, vertices);

            // Create a vertex buffer binding
            var vertexBufferBinding = new VertexBufferBinding(vertexBuffer, layout, vertexCount);

            var pipelineStateDescription = new PipelineStateDescription();
            var pipelineState = PipelineState.New(Level.Graphics, ref pipelineStateDescription);
            pipelineStateDescription.InputElements = new VertexBufferBinding[] { vertexBufferBinding }.CreateInputElements();
            pipelineStateDescription.PrimitiveType = PrimitiveType.TriangleStrip;

            // Create and set a PipelineState object
            CommandList commandList = Level.ListCommand;
            commandList.SetPipelineState(pipelineState);

            // Bind the vertex buffer to the pipeline
            commandList.SetVertexBuffer(0, vertexBuffer, 0, vertexBufferBinding.Stride);

            // Draw the vertices
            commandList.Draw(vertexCount);
        }
    }
}
