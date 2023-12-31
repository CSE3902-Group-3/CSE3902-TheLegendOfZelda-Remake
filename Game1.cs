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
        private readonly int ViewportHeight = 896;

        /* ini Config Reader */
        public ReadConfig ReadConfig = new ReadConfig("config.ini");

        /* Game Difficulty */
        public float Difficulty;
        public static int frameNumber { get; private set; } = 0;

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

            if(ShaderHolder.ShadersOn) ShaderHolder.LoadShaders(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.getInstance().LoadTextures();
            SoundFactory.getInstance().LoadTextures();
            LevelUtilities.SetLevelLoadingValues(SpriteFactory.getInstance().scale);

            Difficulty = float.Parse(ReadConfig.GameConfig["Game.Difficulty"]);
            // Game state
            GameState = GameState.GetInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            frameNumber++;
            GameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GameState.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}