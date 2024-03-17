using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame_Snake.Models
{    
    public class Core
    {
        public GraphicsDeviceManager Graphics { get; }
        public SpriteBatch? SpriteBatch { get; set; }

        public Core(GraphicsDeviceManager graphics)
        {
            Graphics = graphics;
        }

        public Vector2 RandomPosition(int height)
        {
            //get random position related to the height of the texture to avoid the food to be out of the screen

            var x = new System.Random().Next(0, Graphics.PreferredBackBufferWidth / height) * height;
            var y = new System.Random().Next(0, Graphics.PreferredBackBufferHeight / height) * height;
            return new Vector2(x, y);
        }
    }
}
