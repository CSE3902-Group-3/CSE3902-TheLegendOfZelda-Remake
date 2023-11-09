using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public enum Direction { down, right, up, left, upLeft, upRight, downLeft, downRight };
    public class Game1 : Game
    {
        /* Graphics */
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch { get; private set; }

        /* Game State */
        private GameState GameState;

        /* Singleton */
        private static Game1 instance;

        /* Viewport */
        private readonly int ViewportWidth = 1024;
        private readonly int ViewportHeight = 1024;

        private Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public static Game1 getInstance()
        {
            if (instance == null)
                instance = new Game1();

            return instance;
        }

        protected override void Initialize()
        {
            instance = this;

            SpriteFactory.getInstance();
            SoundFactory.getInstance();

            // Change size of viewport
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = ViewportWidth;
            _graphics.PreferredBackBufferHeight = ViewportHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.getInstance().LoadTextures();
            SoundFactory.getInstance().LoadTextures();

            // Game state
            GameState = GameState.GetInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            GameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Matrix transformMatrix = Matrix.CreateTranslation(-GameState.CameraController.mainCamera.worldPos.X, -GameState.CameraController.mainCamera.worldPos.Y, 0);
            _spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            GameState.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}