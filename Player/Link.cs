using LegendOfZelda.Interfaces;
using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Player
{
    public class Link : IPlayer
    {
        public Rectangle Hitbox { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public LinkStateMachine StateMachine { get; set; }
        //public States.LinkState State { get; set; } = ;
        public int HP { get; set; } = 6;
        public int MaxHP { get; set; } = 6;
        public bool CanMove { get; set; } = true;

        public Link(Vector2 position)
        {
            Position = position;
            StateMachine = new LinkStateMachine();
            StateMachine.ChangeState(null); // chhange to default state
        }

        public void Update(GameTime gameTime)
        {
            // update
        }

        public void Update()
        {
            // update
        }

        public void Draw()
        {
            // Sprite.Draw(Position);
        }

    }
}
