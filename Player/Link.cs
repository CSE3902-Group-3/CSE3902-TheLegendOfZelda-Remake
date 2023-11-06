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

        public float HP { get; private set; } = 6;
        public float maxHP { get; private set; } = 6;

        public int velocity { get; set; } = 5; // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        private float damageAnimationTimer = 0; // Initialize it to 0
        private float damageAnimationDuration = 1.0f; // Set the duration (in seconds) for the animation

        public float damageCooldownTimer  = 0; // Set the cooldown (in seconds) for damage
        public float damageCooldownDuration = 1.0f;

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
            this.sprite.UpdatePos(LinkUtilities.originalLinkPosition);

            this.stateMachine = new LinkStateMachine();
            this.stateMachine.ChangeState(new InititalLinkState(this.sprite));

            collider = new RectCollider(
                new Rectangle((int)this.stateMachine.position.X, (int)+this.stateMachine.position.Y, 16 * SpriteFactory.getInstance().scale, 16 * SpriteFactory.getInstance().scale),
                CollisionLayer.Player,
                this,
                true
            );
            LinkUtilities.UpdatePositions(this, this.sprite.pos);

            LevelMaster.RegisterUpdateable(this, true);
        }

        public void TakeDamage(float damage)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().LinkHurt, 1.0f, 0.0f, 0.0f);
            this.HP -= damage;
            if (this.HP <= 0)
            {
                this.Die();
                SoundFactory.PlaySound(SoundFactory.getInstance().LinkDie, 1.0f, 0.0f, 0.0f);
            }
            this.stateMachine.isTakingDamage = true;
            this.damageAnimationTimer = this.damageAnimationDuration;
            this.damageCooldownTimer = this.damageCooldownDuration;
        }

        public void StopTakingDamage()
        {
            this.stateMachine.isTakingDamage = false;
        }

        public void Update (GameTime gameTime)
        {
            damageCooldownTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (damageAnimationTimer > 0)
            {
                damageAnimationTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (damageAnimationTimer <= 0)
                {
                    // Stop the flashing animation and reset any related variables.
                    damageAnimationTimer = 0;
                    StopTakingDamage();
                }
            }

            if (LinkUtilities.LinkChangedDirection())
            {
                this.velocity = 5;
            }

            this.stateMachine.Update();
            LinkUtilities.UpdatePositions(this, this.sprite.pos);

            ((AnimatedSprite)this.sprite).flashing = this.stateMachine.isTakingDamage;
        }

        public void Reset()
        {
            LinkUtilities.UpdatePositions(this, LinkUtilities.originalLinkPosition);
            this.stateMachine.ChangeState(new WalkRightLinkState());
            this.stateMachine.ChangeState(new IdleLinkState());

            this.HP = this.maxHP;
        }

        public void Die()
        {
            // just call Reset for now
            this.Reset();
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            LinkCollisionHandler.OnCollision(collisions);
        }

        public void EnterRoomTransition()
        {
            this.stateMachine.ChangeState(new RoomTransitionLinkState());
        }
        public void ExitRoomTransition()
        {
            // i don't think we need this??
        }
    }
}
