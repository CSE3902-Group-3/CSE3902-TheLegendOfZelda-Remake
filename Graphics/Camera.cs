using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Camera : IUpdateable
    {
        public Vector2 worldPos { get; set; }
        public bool panning = false;

        private float speed = 0;
        private Vector2 targetPos;
        private Action callback;
        private IDrawer drawer;

        public Camera(Vector2 worldPos)
        {
            this.worldPos = worldPos;
            LevelManager.AddUpdateable(this, true);
            drawer = ShaderHolder.ShadersOn ? new ShaderDrawer() : new StandardDrawer();
        }
        public void DrawAll(List<IDrawable> drawables, SpriteBatch spriteBatch)
        {
            Matrix transformMatrix = Matrix.CreateTranslation(-worldPos.X, -worldPos.Y, 0);

            drawer.Draw(drawables, transformMatrix, spriteBatch);
        }

        //This method is offered as an alternative in case a list of lists is wanted to be drawn
        public void DrawAll(List<List<IDrawable>> drawables, SpriteBatch spriteBatch)
        {
            Matrix transformMatrix = Matrix.CreateTranslation(-worldPos.X, -worldPos.Y, 0);

            foreach (List<IDrawable> drawableList in drawables)
            {
                drawer.Draw(drawableList, transformMatrix, spriteBatch);
            }
        }
        public void PanToLocation(Vector2 newWorldPos, float speed, Action OnComplete = null)
        {
            this.speed = speed;
            targetPos = newWorldPos;
            panning = true;
            callback = OnComplete;
        }

        private void Move()
        {
            if (speed != 0)
            {
                worldPos += speed * Vector2.Normalize(targetPos - worldPos);
                if (float.IsNaN(worldPos.X) &&  float.IsNaN(worldPos.Y)) { worldPos = targetPos; }
                if(Vector2.Distance(targetPos, worldPos) <= speed)
                {
                    worldPos = targetPos;
                    speed = 0;
                    panning = false;

                    if(callback != null)
                    {
                        callback();
                        callback = null;
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Move();
        }
    }


}
