using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net;

namespace LegendOfZelda
{
    public class Camera : IUpdateable
    {
        public Vector2 worldPos { get; set; }
        public bool panning = false;

        private float speed = 0;
        private Vector2 targetPos;
        private Action callback;
        public Camera(Vector2 worldPos)
        {
            this.worldPos = worldPos;
            LevelMaster.RegisterUpdateable(this, true);
        }

        public void DrawAll(List<IDrawable> drawables, SpriteBatch spriteBatch)
        {
            Matrix transformMatrix = Matrix.CreateTranslation(-worldPos.X, -worldPos.Y, 0);

            spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            foreach(IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            spriteBatch.End();
        }

        public void DrawAll(List<List<IDrawable>> drawables, SpriteBatch spriteBatch)
        {
            Matrix transformMatrix = Matrix.CreateTranslation(-worldPos.X, -worldPos.Y, 0);

            spriteBatch.Begin(SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            foreach (List<IDrawable> drawableList in drawables)
            {
                foreach(IDrawable drawable in drawableList)
                {
                    drawable.Draw();
                }
            }
            spriteBatch.End();
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
