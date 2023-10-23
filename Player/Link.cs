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
        public RectCollider collider { get; set; }

        public LinkStateMachine stateMachine { get; private set; }

        private int HP { get; set; } = 6;
        private int maxHP { get; set; } = 6;

        public int velocity { get; set; } = 5; // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        private static Link instance;

        public static Link getInstance()
        {
            if (instance == null)
                instance = new Link();

            return instance;
        }

        private Link()
        {
            this.game = Game1.getInstance();

            this.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
            this.sprite.UpdatePos(new Vector2(448, 864));

            this.stateMachine = new LinkStateMachine();
            this.stateMachine.ChangeState(new InititalLinkState(this.sprite));

            this.stateMachine.linkInventory = new Inventory();

            collider = new RectCollider(
                new Rectangle((int)this.stateMachine.position.X, (int)+this.stateMachine.position.Y, 16 * SpriteFactory.getInstance().scale, 16 * SpriteFactory.getInstance().scale),
                CollisionLayer.Player,
                this
            );
            LinkUtilities.UpdatePositions(this, this.sprite.pos);
        }

        public void TakeDamage()
        {
            this.stateMachine.isTakingDamage = true;
        }

        public void Heal()
        {
            this.stateMachine.isTakingDamage = false;
        }

        public void Update (GameTime gameTime)
        {
            if (ChangedDirection())
            {
                this.velocity = 5;
            }

            this.stateMachine.Update();
            LinkUtilities.UpdatePositions(this, this.sprite.pos);
        }

        public void Reset()
        {
            ((AnimatedSprite)sprite).UpdatePos(new Vector2(0,0));
            this.stateMachine.position = new Vector2(0, 0);
            this.stateMachine.ChangeState(new WalkRightLinkState());
            this.stateMachine.ChangeState(new IdleLinkState());
        }

        private bool ChangedDirection()
        {
            return stateMachine.prevDirection != stateMachine.currentDirection;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                /*
                 * You will likely need to sort out the collisions by the Layer of the collidable you collided with
                 */
                if (collision.CollidedWith.Layer == CollisionLayer.OuterWall || collision.CollidedWith.Layer == CollisionLayer.Wall)
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
            Vector2 newPosition = this.sprite.pos;

            switch (direction)
            {
                case Direction.up:
                    newPosition.Y += overlapRectangle.Height;
                    break;
                case Direction.down:
                    newPosition.Y -= overlapRectangle.Height;
                    break;
                case Direction.right:
                    newPosition.X -= overlapRectangle.Width;
                    break;
                case Direction.left:
                    newPosition.X += overlapRectangle.Width;
                    break;
            }

            LinkUtilities.UpdatePositions(this, newPosition);
            this.velocity = 0;
        }

        private void HandleCollisionWithEntity()
        {
            //do nothing for now
        }

    }
}
