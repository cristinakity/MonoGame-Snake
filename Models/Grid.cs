using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Models
{
    public class Grid
    {
        private int width;
        private int height;
        private int cellSize;
        private Color color;
        private GraphicsDevice graphicsDevice;
        private BasicEffect basicEffect;

        public Grid(int width, int height, int cellSize, Color color, GraphicsDevice graphicsDevice)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.color = color;
            this.graphicsDevice = graphicsDevice;

            basicEffect = new BasicEffect(graphicsDevice);
            basicEffect.VertexColorEnabled = true;
        }

        public void Draw()
        {
            //Don't draw the grid over the banner
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
            basicEffect.View = Matrix.Identity;
            basicEffect.World = Matrix.Identity;

            VertexPositionColor[] vertices = new VertexPositionColor[(width + height + 2) * 2];

            int counter = 0;

            for (int x = 0; x <= width; x++)
            {
                vertices[counter++] = new VertexPositionColor(new Vector3(x * cellSize, 0, 0), color);
                vertices[counter++] = new VertexPositionColor(new Vector3(x * cellSize, height * cellSize, 0), color);
            }

            for (int y = 0; y <= height; y++)
            {
                vertices[counter++] = new VertexPositionColor(new Vector3(0, y * cellSize, 0), color);
                vertices[counter++] = new VertexPositionColor(new Vector3(width * cellSize, y * cellSize, 0), color);
            }

            basicEffect.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, (width + height + 2));
        }
    }
}