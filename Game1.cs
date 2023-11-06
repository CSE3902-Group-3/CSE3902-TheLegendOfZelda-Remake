using LegendOfZelda.Graphics;
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
        public SpriteFactory spriteFactory { get; private set; }

        /* Game State */
        private GameState GameState;
        public Link link;

        /* Cylers */
        public RoomCycler roomCycler { get; private set; }

        /* Level */
        private LevelMaster LevelMaster;
        
        /* Sounds */
        public SoundFactory SoundFactory { get; private set; }

        /* Singleton */
        private static Game1 instance;

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

            spriteFactory = SpriteFactory.getInstance();
            SoundFactory = SoundFactory.getInstance();

            // Change size of viewport
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 1024;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteFactory.LoadTextures();
            SoundFactory.LoadTextures();

            // Game state
            GameState = GameState.GetInstance();

            // Level
            LevelMaster = LevelMaster.GetInstance();
            roomCycler = new RoomCycler(LevelMaster);

            // Will have to change this later
            link = GameState.Link;

            BackgroundGenerator.GenerateMenuBackgrounds();
            new Staircase(new Vector2(1500, 600));
            new LadderDoor(new Vector2(1700, 600));
        }

        protected override void Update(GameTime gameTime)
        {
            GameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // this is scuffed I know, but its the only way I know how to get this to work
            // problem is the pause manager drawing something separate from camera
            Matrix transformMatrix = Matrix.CreateTranslation(-GameState.CameraController.mainCamera.worldPos.X, -GameState.CameraController.mainCamera.worldPos.Y, 0);
            _spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            GameState.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}