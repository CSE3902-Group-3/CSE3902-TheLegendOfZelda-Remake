using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch { get; private set; }
        private List<iUpdateable> updateables;
        private List<iDrawable> drawables;
        public SpriteFactory spriteFactory { get; private set; }

        public static Game1 instance { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            instance = this;
            updateables = new List<iUpdateable>();
            drawables = new List<iDrawable>();

            spriteFactory = new SpriteFactory(8, 8);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spriteFactory.LoadTextures();

            //Uncomment the following line for testing
            new AnimationTester();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (iUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            foreach(iDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public bool RegisterDrawable(iDrawable drawable)
        {
            if (drawables.Contains(drawable))
            {
                return false;
            }

            drawables.Add(drawable);
            return true;
        }

        public bool RegisterUpdateable(iUpdateable updateable)
        {
            if (updateables.Contains(updateable))
            {
                return false;
            }

            updateables.Add(updateable);
            return true;
        }

        public bool RemoveDrawable(iDrawable drawable)
        {
            if (!drawables.Contains(drawable))
            {
                return false;
            }

            drawables.Remove(drawable);
            return true;
        }

        public bool RemoveUpdateable(iUpdateable updateable)
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