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

        /* Link */
        public IPlayer link { get; private set; }

        /* Controller */
        private IController controller;

        /* Cylers */
        public RoomCycler roomCycler { get; private set; }

        /* Level */
        private LevelMaster LevelMaster;

        /* Camera Controller */
        private CameraController CameraController;

        /* Collisions */
        private CollisionManager collisionManager;

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

            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteFactory.LoadTextures();
            SoundFactory.LoadTextures();

            // Level 1
            LevelMaster = LevelMaster.GetInstance();

            LevelMaster.StartLevel("level1.json");

            link = Link.getInstance();


            roomCycler = new RoomCycler(LevelMaster);

            controller = new PlayerController((Link)link);

            CameraController = CameraController.GetInstance();
            BackgroundGenerator.GenerateMenuBackgrounds();
            new CameraControllerTest();

        }

        protected override void Update(GameTime gameTime)
        {          
            LevelMaster.Update(gameTime);

            controller.Update();
            //CollisionManager always updates last
            collisionManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            CameraController.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}