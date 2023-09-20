using LegendOfZelda.Interfaces;
using LegendOfZelda;
using Microsoft.Xna.Framework;
using LegendOfZelda.StateMachine.Link.LinkStates;

namespace LegendOfZelda.Player
{
    public class Link : IPlayer
    {
        public enum Direction { Up, Down, Left, Right };

        private Game1 game { get; set; }
        public ISprite sprite { get; set; }

        public Direction currentDirection { get; set; } = Direction.Right;
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
            this.stateMachine.ChangeState(new IdleLinkState());
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
