using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using LegendOfZelda;

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
        public BlockCycler blockCycler { get; private set; }
        public EnemyCycler enemyCycler { get; private set; }
        public ItemScroll itemCycler { get; private set; }
        public RoomCycler roomCycler { get; private set; }

        public LetterTester letterTester { get; private set; }

        /* Level */
        private LevelMaster LevelMaster;

        /* Collisions */
        private CollisionManager collisionManager;

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
            // TODO: Add your initialization logic here
            instance = this;

            spriteFactory = SpriteFactory.getInstance();

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

            // TODO: use this.Content to load your game content here
            spriteFactory.LoadTextures();

            link = Link.getInstance();

            // Level 1
            LevelMaster = LevelMaster.GetInstance();
            LevelMaster.StartLevel("level1.json");

            //blockCycler = new BlockCycler(new Vector2(300, 200));
            //enemyCycler = new EnemyCycler(new Vector2(500, 500));
            //itemCycler = new ItemScroll(new Vector2(800, 600));
            roomCycler = new RoomCycler(LevelMaster);
            //new AnimationTester();
            letterTester = new LetterTester();

            controller = new PlayerController((Link)link);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            // TODO: Add your update logic here
            
            LevelMaster.Update(gameTime);
            link.Update(gameTime);

            controller.Update();
            //CollisionManager always updates last
            collisionManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            LevelMaster.Draw();
            link.sprite.Draw();
            letterTester.Show();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}