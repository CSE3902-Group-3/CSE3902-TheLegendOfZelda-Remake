using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using static LegendOfZelda.SimpleEnemyStateMachine;
using static System.Formats.Asn1.AsnWriter;

namespace LegendOfZelda
{
    public class Link : IPlayer, ICollidable, IUpdateable
    {
        private Game1 game { get; set; }
        public ISprite sprite { get; set; }
        public Vector2 pos { get { return sprite.pos; } }
        private IRectCollider collider;

        public Direction currentDirection { get; set; } = Direction.right;
        public LinkStateMachine stateMachine { get; private set; }

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

            collider = new RectCollider(
                new Rectangle((int)this.stateMachine.position.X, (int)+this.stateMachine.position.Y, 16, 16),
                CollisionLayer.Player,
                this
            );
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

        public void Reset()
        {
            ((AnimatedSprite)sprite).UpdatePos(new Vector2(0,0));
            this.stateMachine.ChangeState(new WalkRightLinkState());
            this.stateMachine.ChangeState(new IdleLinkState());
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                /*
                 * You will likely need to sort out the collisions by the Layer of the collidable you collided with
                 */
                if (collision.CollidedWith.Layer == CollisionLayer.Wall)
                {
                    HandleCollisionWithWall(collision.EstimatedDirection, collision.OverlapRectangle);
                }
                else
                {
                    HandleCollisionWithEntity();
                }
            }
        }

        private void HandleCollisionWithWall(Direction direction, Rectangle overlapRectangle)
        {
            switch (direction)
            {
                case Direction.up:
                    this.stateMachine.position = new Vector2(this.stateMachine.position.X, this.stateMachine.position.Y + overlapRectangle.Height);
                    break;
                case Direction.down:
                    this.stateMachine.position = new Vector2(this.stateMachine.position.X, this.stateMachine.position.Y - overlapRectangle.Height);
                    break;
                case Direction.right:
                    this.stateMachine.position = new Vector2(this.stateMachine.position.X - overlapRectangle.Width, this.stateMachine.position.Y);
                    break;
                case Direction.left:
                    this.stateMachine.position = new Vector2(this.stateMachine.position.X + overlapRectangle.Width, this.stateMachine.position.Y);
                    break;
            }
        }

        private void HandleCollisionWithEntity()
        {
            //do nothing for now
        }

    }
}
