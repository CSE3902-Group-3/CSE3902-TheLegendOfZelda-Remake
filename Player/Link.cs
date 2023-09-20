using LegendOfZelda.Interfaces;
using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Player
{
    public class Link : IPlayer
    {
        private Game1 game { get; set; }
        public ISprite sprite { get; set; }
        private LinkStateMachine stateMachine { get; set; }
        private int HP { get; set; } = 6;
        private int haxHP { get; set; } = 6;
        private bool canMove { get; set; } = true;


        public Link(Game1 game, ISprite linkDefaultSprite)
        {
            this.game = game;

            this.sprite = linkDefaultSprite;
            game.RegisterDrawable(sprite);

            this.stateMachine = new LinkStateMachine();
            //this.stateMachine.ChangeState(null); // set to default state
        }

        public void Update (GameTime gameTime)
        {
            // do nothing
        }

        public void UseItem()
        {
            // do nothing
        }

        public void Reset()
        {             
            // do nothing
        }

        public void ChangeItem(int index)
        {
            // do nothing
            // index will be pos in inventory
        }

        public void ChangeWeapon(int index)
        {
            // do nothing
            // index will be pos in inventory
        }

    }
}
