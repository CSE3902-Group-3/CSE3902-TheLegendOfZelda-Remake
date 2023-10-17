using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Fairy : IItem, IUpdateable, ICollidable
    {
        protected AnimatedSprite fairy;
        private Vector2 position;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;
        private Timer timer;

        public Fairy(Vector2 pos)
        {
            fairy = SpriteFactory.getInstance().CreateFairySprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            LevelMaster.RegisterUpdateable(this);
            fairy.RegisterSprite();
            fairy.UpdatePos(position);
        }

        /* this is added in case fairy should be displayed in inventory, where it should not move */
        public void ShowIdle()
        {
            fairy.RegisterSprite();
            fairy.UpdatePos(position);
        }

        public void Remove()
        {
            fairy.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
        }

        public IItem Collect()
        {
            fairy.UnregisterSprite();
            return this;
        }

        public void Update(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();

        }

        public void ChangeDirection()
        {
            Random rand = new();
            int random = rand.Next(0, 8);

            if (random == 0)
            {
                Direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                Direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                Direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                Direction = new Vector2(0, -1);
            }
            else if (random == 4)
            {
                Direction = new Vector2(1, 1);
            }
            else if (random == 5)
            {
                Direction = new Vector2(-1, 1);
            }
            else if (random == 6)
            {
                Direction = new Vector2(1, -1);
            }
            else if (random == 7)
            {
                Direction = new Vector2(-1, -1);
            }
        }
        public void ChangePosition()
        {
            position += Direction * 2;
            if (position.X < 0 || position.Y < 0)
            {
                position -= Direction * 2;
            }

            if (position.X >= ViewportSize.X || position.Y >= ViewportSize.Y)
            {
                ChangeDirection();
            }
            fairy.UpdatePos(position);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall)
                {
                    ChangeDirection();
                }

                //The part below only meet requirement for sprint3 and should be refactored in sprint4
                if (collidedWith == CollisionLayer.Player)
                {
                    Collect();
                }
            }
        }
    }
}