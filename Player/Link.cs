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
        private RectCollider collider;
        public Direction prevDirection;

        public Direction currentDirection { get; set; } = Direction.right;
        public LinkStateMachine stateMachine { get; private set; }

        public bool isTakingDamage { get; private set; }

        private int HP { get; set; } = 6;
        private int maxHP { get; set; } = 6;
        private bool canMove { get; set; } = true;

        public int velocity { get; set; } = 5; // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        public Link()
        {
            this.game = Game1.getInstance();

            this.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();

            this.stateMachine = new LinkStateMachine();
            this.stateMachine.ChangeState(new InititalLinkState(this.sprite));

            collider = new RectCollider(
                new Rectangle((int)this.stateMachine.position.X, (int)+this.stateMachine.position.Y, 16 * SpriteFactory.getInstance().scale, 16 * SpriteFactory.getInstance().scale),
                CollisionLayer.Player,
                this
            );
            this.stateMachine.position = this.sprite.pos;
            collider.Pos = this.stateMachine.position;

            game.RegisterUpdateable(this);
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
            collider.Pos = this.stateMachine.position;

            if (ChangedDirection())
            {
                this.velocity = 5;
            }

            this.stateMachine.Update();
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
            return prevDirection != currentDirection;
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
            switch (direction)
            {
                case Direction.up:
                    this.sprite.UpdatePos(new Vector2(this.sprite.pos.X, this.sprite.pos.Y + overlapRectangle.Height));
                    this.velocity = 0;
                    break;
                case Direction.down:
                    this.sprite.UpdatePos(new Vector2(this.sprite.pos.X, this.sprite.pos.Y - overlapRectangle.Height));
                    this.velocity = 0;
                    break;
                case Direction.right:
                    this.sprite.UpdatePos(new Vector2(this.sprite.pos.X - overlapRectangle.Width, this.sprite.pos.Y));
                    this.velocity = 0;
                    break;
                case Direction.left:
                    this.sprite.UpdatePos(new Vector2(this.sprite.pos.X + overlapRectangle.Width, this.sprite.pos.Y));
                    this.velocity = 0;
                    break;
            }

            this.stateMachine.position = this.sprite.pos;
        }

        private void HandleCollisionWithEntity()
        {
            //do nothing for now
        }

    }
}
