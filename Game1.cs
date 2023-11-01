using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using LegendOfZelda;
using LegendOfZelda.Graphics;

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

        /* Camera Controller */
        private CameraController CameraController;
        
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
        }

        protected override void Update(GameTime gameTime)
        {
            GameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            GameState.Draw();

            _spriteBatch.End();
            CameraController.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}