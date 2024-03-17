using Microsoft.Xna.Framework;

namespace MonoGame_Snake.Extensions
{
    public static class Extensions
    {
        public static void Center(this Vector2 position, GraphicsDeviceManager graphics)
        {
            var x = graphics.PreferredBackBufferWidth / 2;
            var y = graphics.PreferredBackBufferHeight / 2;
            position.X = x;
            position.Y = y;
        }
    }
}