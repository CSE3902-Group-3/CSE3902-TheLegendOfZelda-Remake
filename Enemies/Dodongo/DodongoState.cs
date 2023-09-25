﻿using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.InteropServices;

namespace LegendOfZelda.Enemies.Dodongo
{
    public class DodongoState : IEnemy
    {
        public IEnemy State { get;  set; }
        private double LastDirSwitch = 0;
        private double LastHealthSwitch = 0;

        public DodongoState(Vector2 pos)
        {
            State = new RightMovingDodongo(this, pos);
            Spawn();
        }
        public void Spawn()
        {
            Game1.instance.RegisterUpdateable(this);
            State.Spawn();
        }
        public void ChangePosition()
        {
            State.ChangePosition();
        }
        public void Attack()
        {
            State.Attack();
        }
        public void UpdateHealth()
        {
            State.UpdateHealth();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastDirSwitch + 2000)
            {
                LastDirSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                State.ChangeDirection();
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > LastHealthSwitch + 333)
            {
                LastHealthSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                State.UpdateHealth();
            }
            State.ChangePosition();
        }
        public void Die()
        {
            State.Die();
        }
    }
}