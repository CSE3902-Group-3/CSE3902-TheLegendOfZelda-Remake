using LegendOfZelda.Environment;
using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using LegendOfZelda.StateMachine.LinkStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;
using IDrawable = LegendOfZelda.Interfaces.IDrawable;
using IUpdateable = LegendOfZelda.Interfaces.IUpdateable;

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

        /* Link */
        public IPlayer link { get; private set; }

        /* Controller */
        private IController controller;
        public BlockCycler blockCycler { get; private set; }

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
            updateables = new List<IUpdateable>();

            spriteFactory = new SpriteFactory(8, 8);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            drawables = new List<IDrawable>();

            spriteFactory.LoadTextures();

            blockCycler = new BlockCycler(new Vector2(300, 200));
            //Uncomment the following line for testing
            new AnimationTester();

            link = new Link(this);

            //Uncomment the following line for testing
            //new AnimationTester();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < updateables.Count; i++)
            {
                    updateables[i].Update(gameTime);
            }

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