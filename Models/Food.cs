using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_Snake.Enums;

namespace MonoGame_Snake.Models
{
    public class Food
    {
        private Core _core;
        public Texture2D? Texture { get; set; }
        public Vector2 Position { get; set; }
        public FoodState foodState { get; set; }

        public Food(Core core)
        {
            _core = core;
        }

        public void Draw(Vector2? position = null)
        {
            _core.SpriteBatch?.Draw(Texture, position ?? Position, Color.White);
            Position = position ?? Position;
        }

        public void ShowPosition(SpriteFont font, float scale, Vector2 position)
        {
            _core.SpriteBatch?.DrawString(font, $"Food Position x={Position.X} y={Position.Y}", position, Color.Black, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }

}