using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Models;
using MonoGame_Snake.Models;

namespace MonoGame_Snake
{
    public class Game1 : Game
    {
        private Core _core;
        private Snake _snake;
        private Food _food;
        private Grid _grid;
        Texture2D pixelTexture;

        private int _bannerSize = 50;
        // Variable to track elapsed time
        float elapsedTime = 0f;

        public Game1()
        {
            var graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 2000;
            graphics.PreferredBackBufferHeight = 950;
            graphics.IsFullScreen = false;
            _core = new Core(graphics);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _snake = new Snake(_core);
            _food = new Food(_core);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _core.SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a 1x1 white pixel texture
            pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            pixelTexture.SetData(new Color[] { Color.White });

            //Add textures to the snake and food
            SetTextures();
            _food.Position = _snake.RandomPositionWithoutSnake(_bannerSize);

            //Prepare the Grid
            var gridWidth = _core.Graphics.PreferredBackBufferWidth / _snake.BodySize;
            var gridHeight = _core.Graphics.PreferredBackBufferHeight / _snake.BodySize;
            _grid = new Grid(gridWidth, gridHeight, _snake.BodySize, Color.Black, GraphicsDevice);
        }

        private void SetTextures()
        {
            _snake.TextureBody = Content.Load<Texture2D>("snakeBodyOk"); 
            _snake.TextureHead = Content.Load<Texture2D>("snakeHeadOk");
            _snake.TextureTail = Content.Load<Texture2D>("snakeTail");
            _snake.TextureBodyCorner = Content.Load<Texture2D>("snakeCorner");
            _food.Texture = Content.Load<Texture2D>("foodOk");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.R))
            {
                Reset();
            }   

            // To change the Direction of the snake
            _snake.Update(keyboardState);

            if(elapsedTime > _snake.Speed)
            {
                elapsedTime = 0;
                _snake.Move(_bannerSize);
                //Validate if food was eaten
                //var adjustedFoodPosition = new Vector2(_food.Position.X + _snake.BodySize, _food.Position.Y + +_snake.BodySize);
                if (_snake.PositionHead == _food.Position)
                {
                    _food.Position = _snake.RandomPositionWithoutSnake(_bannerSize);
                    _snake.Length++;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            //Draw a grid of the size of the snake

            _core.SpriteBatch?.Begin();

            DrawBanner();
            _snake.Draw();
            //_grid.Draw();
            //_food.Position = _snake.RandomPositionWithoutSnake();
            _food.Draw();

            _core.SpriteBatch?.End();

            base.Draw(gameTime);
        }

        private void DrawBanner()
        {
            AddBannerBackground();

            float scale = 2.0f; // You can adjust this value to make the text larger or smaller
            var font = Content.Load<SpriteFont>("FontArial");
            _snake.ShowPosition(font, scale, new Vector2(10, 10));
            _food.ShowPosition(font, scale, new Vector2(500, 10));
            _snake.ShowSpeed(font, scale, new Vector2(1000, 10));
            //Add big text to show the score

            // Draw the text with a larger size
            _core.SpriteBatch?.DrawString(font, $"Score={_snake.Length}", new Vector2(1600, 10), Color.Black, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

        }

        private void AddBannerBackground()
        {
            // Rectangle position and size
            Rectangle rectangle = new Rectangle(0, 0, _core.Graphics.PreferredBackBufferWidth, _bannerSize); // (x, y, width, height)

            // Color of the rectangle
            Color color = Color.Coral;

            // Draw the rectangle
            _core.SpriteBatch?.Draw(pixelTexture, rectangle, color);

            //_core.SpriteBatch?.DrawRectangle(new Rectangle(0, 0, _core.Graphics.PreferredBackBufferWidth, _bannerSize), Color.Gray);
        }

        private void Reset()
        {
            _snake = new Snake(_core);
            _food = new Food(_core);
            SetTextures();
            _food.Position = _snake.RandomPositionWithoutSnake(_bannerSize);
        }   
    }
}