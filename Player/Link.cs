using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using LegendOfZelda.StateMachine.LinkStates;

namespace LegendOfZelda.Player
{
    public class Link : IPlayer
    {
        public enum Direction { Up, Down, Left, Right };

        private Game1 game { get; set; }
        public ISprite sprite { get; set; }

        public Direction currentDirection { get; set; } = Direction.Right;
        public LinkStateMachine stateMachine { get; private set; }
        private int HP { get; set; } = 6;
        private int maxHP { get; set; } = 6;
        private bool canMove { get; set; } = true;

        //TEMPORARY, not implemented
        public Vector2 pos { get { return Vector2.Zero; } }


        public Link(Game1 game)
        {
            this.game = game;

            this.sprite = game.spriteFactory.CreateLinkWalkRightSprite();

            this.stateMachine = new LinkStateMachine();
            this.stateMachine.ChangeState(new InititalLinkState(this.game, this.sprite));
        }

        public void Update (GameTime gameTime)
        {
            // do nothing
            // this is inherited from iUpdateable, maybe it isn't needed but I would like to leave it for sprint2
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
