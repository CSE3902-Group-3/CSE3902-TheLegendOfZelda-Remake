﻿using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        public IState PrevState { get; private set; } = new IdleLinkState();
        public IState CurrentState { get; private set; }
        public Direction currentDirection { get; set; } = Direction.right;
        public Direction prevDirection;

        public Vector2 position = new Vector2(0,0);

        public Inventory linkInventory { get; } = Inventory.getInstance();
        public bool canMove { get; set; } = true;
        public bool isWalking { get; set; } = false;

        public bool isTakingDamage { get; set; } = false;
        public bool isKnockedBack { get; set; } = false;

        public void ChangeState(IState newState)
        {
            if (LinkUtilities.IsStateWithIncompleteAnimation(this.CurrentState)) return;
            if (isKnockedBack) return;

            // only change if states are different
            if (CurrentState != null && (newState.GetType() == CurrentState.GetType())) return;

            Link link = GameState.Link;
            if(link != null)
            {
                position = link.Sprite.pos;
            }

            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            PrevState = CurrentState;
            CurrentState = newState;
            CurrentState.Enter();

            if(link != null)
            {
                LinkUtilities.UpdatePositions(link, position);
            }
        }

        public void Update()
        {
            CurrentState.Execute();
        }
    }
}
