using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using IDrawable = LegendOfZelda.Interfaces.IDrawable;
using IUpdateable = LegendOfZelda.Interfaces.IUpdateable;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch { get; private set; }
        private List<IUpdateable> updateables;
        private List<IDrawable>[] drawables;
        public SpriteFactory spriteFactory { get; private set; }
        private Effect[] shaders;
        public int numShaders
        {
            get { return shaders.Length; }
        }

        private IController controller;

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
            shaders = new Effect[]
            {
                Content.Load<Effect>("normal"),
                Content.Load<Effect>("flash1"),
                Content.Load<Effect>("flash2"),
                Content.Load<Effect>("blink")
            };

            drawables = new List<IDrawable>[shaders.Length];
            for (int i = 0; i < drawables.Length; i++)
            {
                drawables[i] = new List<IDrawable>();
            }

            spriteFactory.LoadTextures();

            //Uncomment the following line for testing
            new AnimationTester();
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            controller = new PlayerController(this);

            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
                
            }

            controller.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            for(int i = 0; i < drawables.Length; i++)
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, effect: shaders[i]);
                for(int j = drawables[i].Count - 1; j >= 0; j--)
                {
                    drawables[i][j].Draw();
                }
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public bool RegisterDrawable(IDrawable drawable, int effect)
        {
            if (drawables[effect].Contains(drawable))
            {
                return false;
            }

            drawables[effect].Add(drawable);
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

        public bool RemoveDrawable(IDrawable drawable, int effect)
        {
            if (!drawables[effect].Contains(drawable))
            {
                return false;
            }

            drawables[effect].Remove(drawable);
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