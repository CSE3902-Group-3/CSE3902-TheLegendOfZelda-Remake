﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Link : IPlayer, ICollidable, IUpdateable
    {
        public ISprite Sprite { get; set; }
        public Vector2 Pos { get { return Sprite.pos; } }
        public RectCollider Collider { get; set; }
        public LinkStateMachine StateMachine{ get; private set; }
        public float HP { get; private set; } = 6;
        public float MaxHP { get; private set; } = 6;
        public int Velocity { get; set; } = 5; // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        private float damageAnimationTimer = 0; // Initialize it to 0
        private float damageAnimationDuration = 1.0f; // Set the duration (in seconds) for the animation

        public float damageCooldownTimer  = 0; // Set the cooldown (in seconds) for damage
        public float damageCooldownDuration = 1.0f;

        public Link()
        {
            Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
            Sprite.UpdatePos(LinkUtilities.originalLinkPosition);
            StateMachine = new LinkStateMachine();
            StateMachine.ChangeState(new InititalLinkState(this.Sprite));
            Collider = new RectCollider(
                new Rectangle((int)this.StateMachine.position.X, (int)+this.StateMachine.position.Y, 16 * SpriteFactory.getInstance().scale, 16 * SpriteFactory.getInstance().scale),
                CollisionLayer.Player,
                this,
                true
            );
            LinkUtilities.UpdatePositions(this, this.Sprite.pos);
            LevelMaster.RegisterUpdateable(this, true);
        }

        public void Heal(float health)
        {
            if (this.HP + health > this.MaxHP)
                this.HP = this.MaxHP;
            else
                this.HP += health;
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
            this.StateMachine.isTakingDamage = true;
            this.damageAnimationTimer = this.damageAnimationDuration;
            this.damageCooldownTimer = this.damageCooldownDuration;
        }

        public void StopTakingDamage()
        {
            this.StateMachine.isTakingDamage = false;
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
                this.Velocity = 5;
            }

            this.StateMachine.Update();
            LinkUtilities.UpdatePositions(this, this.Sprite.pos);

            ((AnimatedSprite)this.Sprite).flashing = this.StateMachine.isTakingDamage;
        }

        public void Reset()
        {
            GameState.GetInstance().SwitchState(new GameOverState());
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
            this.StateMachine.ChangeState(new RoomTransitionLinkState());
        }
        public void ExitRoomTransition()
        {
            // i don't think we need this??
        }
    }
}
