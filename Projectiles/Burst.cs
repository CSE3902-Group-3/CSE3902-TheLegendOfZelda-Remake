using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Burst : IPlayerProjectile
    {
        private Timer timer;
        private IAnimatedSprite sprite;

        private const double delay = .25;

        public Burst(Vector2 pos)
        {
            sprite = SpriteFactory.getInstance().CreateBurstSprite();
            sprite.UpdatePos(pos);
            LevelManager.CurrentLevelRoom.AddProjectile(this);
            timer = new Timer(delay, Destroy);
        }

        public void Destroy()
        {
            LevelManager.CurrentLevelRoom.RemoveProjectile(this);
            sprite.UnregisterSprite();
        }

        public void Update(GameTime gameTime){}

        public void OnCollision(List<CollisionInfo> collisions){}
    }
}
