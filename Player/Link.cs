using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Link : IPlayer
    {
        private Game1 game { get; set; }
        public ISprite sprite { get; set; }
        public Vector2 pos { get { return sprite.pos; } }

        public Direction currentDirection { get; set; } = Direction.right;
        public LinkStateMachine stateMachine { get; private set; }

        public LinkInventory inventory { get; private set; }
        public IItem currentItem { get; private set;}

        public bool isTakingDamage { get; private set; }

        private int HP { get; set; } = 6;
        private int maxHP { get; set; } = 6;
        private bool canMove { get; set; } = true;

        public int velocity { get; set; } = 5; // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        public Link(Game1 game)
        {
            this.game = game;

            this.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();

            this.stateMachine = new LinkStateMachine();
            this.stateMachine.ChangeState(new InititalLinkState(this.sprite));

            this.inventory = new LinkInventory();
        }

        public void TakeDamage()
        {
            isTakingDamage = true;
        }

        public void Heal()
        {
            isTakingDamage = false;
        }

        public void Update (GameTime gameTime)
        {
            // do nothing
            // this is inherited from iUpdateable, maybe it isn't needed but I would like to leave it for sprint2
        }

        public void UseItem(bool primary)
        {
            if (primary)
            {
                currentItem = inventory.GetPrimaryItem();
            }
            else
            {
                currentItem = inventory.GetSecondaryItem();
            }
        }

        public void Reset()
        {
            ((AnimatedSprite)sprite).UpdatePos(new Vector2(0,0));
            this.stateMachine.ChangeState(new WalkRightLinkState());
            this.stateMachine.ChangeState(new IdleLinkState());
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
