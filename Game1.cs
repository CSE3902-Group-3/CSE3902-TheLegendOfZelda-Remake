using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using LegendOfZelda;

namespace LegendOfZelda
{
    public enum Direction { down, right, up, left };
    public class Game1 : Game
    {
        /* Graphics */
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch { get; private set; }
        private List<IUpdateable> updateables;
        private List<IDrawable> drawables;
        public SpriteFactory spriteFactory { get; private set; }
        public RoomTexture roomTexture { get; private set; }

        /* Link */
        public IPlayer link { get; private set; }


        /* Controller */
        private IController controller;
        public BlockCycler blockCycler { get; private set; }
        public EnemyCycler enemyCycler { get; private set; }

        public ItemScroll itemCycler { get; private set; }
        public RoomCycler roomCycler { get; private set; }
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
            updateables = new List<IUpdateable>();

            spriteFactory = SpriteFactory.getInstance();
            roomTexture = RoomTexture.getInstance();

            // Change size of viewport
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            drawables = new List<IDrawable>();

            roomTexture.LoadTextures();
            spriteFactory.LoadTextures();

            roomCycler = new RoomCycler();
            link = new Link(this);
            blockCycler = new BlockCycler(new Vector2(300, 200));
            enemyCycler = new EnemyCycler(new Vector2(500, 500));
            itemCycler = new ItemScroll(new Vector2(800, 300));
            
            //Uncomment the following line for testing
            new AnimationTester();
            controller = new PlayerController((Link)link);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            // TODO: Add your update logic here
            
            for (int i = 0; i < updateables.Count; i++)
            {
                    updateables[i].Update(gameTime);
            }

            controller.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);
            for(int j = drawables.Count - 1; j >= 0; j--)
            {
                drawables[j].Draw();
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public bool RegisterDrawable(IDrawable drawable)
        {
            if (drawables.Contains(drawable))
            {
                return false;
            }

            drawables.Add(drawable);
            return true;
        }

        public bool RegisterUpdateable(IUpdateable updateable)
        {
            if (updateables.Contains(updateable))
            {
                return false;
            }

            updateables.Add(updateable);
            return true;
        }

        public bool RemoveDrawable(IDrawable drawable)
        {
            if (!drawables.Contains(drawable))
            {
                return false;
            }

            drawables.Remove(drawable);
            return true;
        }

        public bool RemoveUpdateable(IUpdateable updateable)
        {
            if (!updateables.Contains(updateable))
            {
                return false;
            }

            updateables.Remove(updateable);
            return true;
        }
    }
}