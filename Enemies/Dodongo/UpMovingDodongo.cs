﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class UpMovingDodongo : IEnemy
    {
        private readonly DodongoState Dodongo;
        private Vector2 Position;
        private AnimatedSprite Sprite;
        private Vector2 Direction;
        private int MoveMagnitude = 5;
        private bool Injured = false;
        public UpMovingDodongo(DodongoState dodongo, Vector2 pos)
        {
            Dodongo = dodongo;
            Direction = new Vector2(0, -MoveMagnitude);
            Position = pos;
        }
        public void Spawn()
        {
            Sprite = SpriteFactory.getInstance().CreateDodongoUpSprite();
            Sprite.UpdatePos(Position);
        }
        public void UpdateHealth(int damagePoints)
        {
            Sprite.UnregisterSprite();
            if (!Injured)
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoUpHitSprite();
            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateDodongoUpSprite();
            }
            Sprite.UpdatePos(Position);
            Injured = !Injured;
        }
        public void ChangePosition()
        {
            if (!Injured)
            {
                Position += Direction;
                Sprite.UpdatePos(Position);
            }
        }
        public void ChangeDirection()
        {
            Sprite.UnregisterSprite();
            Dodongo.State = new LeftMovingDodongo(Dodongo, Position);
            Dodongo.State.Spawn();
        }
        public void Attack()
        {
            // not needed
        }
        public void Update(GameTime gameTime)
        {
            //handled by Dodongo
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(Dodongo);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            Dodongo.OnCollision(collisions);
        }
    }
}
