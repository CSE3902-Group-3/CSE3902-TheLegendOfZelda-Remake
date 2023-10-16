﻿using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LinkStateMachine
    {
        IState prevState;
        IState currentState;

        public Vector2 position = new Vector2(0,0);
        public Direction prevDirection;

        public Direction currentDirection { get; set; } = Direction.right;

        public Inventory linkInventory { get; set; }
        public IItem currentItem { get; set; }
        public bool isTakingDamage { get; set; }

        public void ChangeState(IState newState)
        {
            // only change if states are different
            if (currentState != null && (newState.GetType() == currentState.GetType())) return;

            Link link = (Link)Game1.getInstance().link;
            if(link != null)
            {
                position = link.sprite.pos;
            }
            
            if (currentState != null)
            {
                currentState.Exit();
            }

            prevState = currentState;
            currentState = newState;
            currentState.Enter();

            if(link != null)
            {
                link.sprite.UpdatePos(position);
            }
        }

        public void Update()
        {
            currentState.Execute();
        }
    }
}
