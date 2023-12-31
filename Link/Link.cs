﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Link : IPlayer, ICollidable, IUpdateable
    {
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Pos { get { return Sprite.pos; } }
        public RectCollider Collider { get; set; }
        public LinkStateMachine StateMachine { get; private set; }
        public float HP { get; private set; } = float.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Health"]);
        public float MaxHP { get; private set; } = float.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Health"]);
        public int Velocity { get; set; } = int.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Speed"]); // link moves at 1pixel per frame in original NES game, scaled up to 1080p is roughly 5pixels per frame

        private float damageAnimationTimer = 0;
        private float damageAnimationDuration = 1.0f; // Set the duration to 1s for damage animation

        public float damageCooldownTimer = 0;
        public float damageCooldownDuration = 3.5f;// Set the cooldown time to 3.5s for damage repeated

        public float spawnProjectileCooldown = 0;
        public float spawnProjectileCooldownDuration = float.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.ProjectileSpawnCooldown"]);  // Set cooldown time to 3 seconds

        private bool invincible = false;
        private double lastLowHealthBeep = 0; // The GameTime when low health sound was last played, initializing to 0
        
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
            LevelManager.AddUpdateable(this, true);
        }

        public void Heal(float health)
        {
            if (this.HP + health > this.MaxHP)
                this.HP = this.MaxHP;
            else
                this.HP += health;
        }

        public void IncreaseMaxHealth()
        {
            if (this.MaxHP < 12)
            {
                this.MaxHP += 1;
            }
        }

        public void TakeDamage(float damage)
        {
            if (!invincible)
            {
                SoundFactory.PlaySound(SoundFactory.getInstance().LinkHurt);
                this.HP -= damage * Game1.getInstance().Difficulty;
                if (this.HP <= 0)
                {
                    this.Die();
                    SoundFactory.PlaySound(SoundFactory.getInstance().LinkDie);
                }

                this.StateMachine.isTakingDamage = true;
                this.damageAnimationTimer = this.damageAnimationDuration;
                this.damageCooldownTimer = this.damageCooldownDuration;
            }
        }

        public void StopTakingDamage()
        {
            this.StateMachine.isTakingDamage = false;
        }

        public void Update(GameTime gameTime)
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
            if (spawnProjectileCooldown > 0)
            {
                spawnProjectileCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (LinkUtilities.LinkChangedDirection())
            {
                this.Velocity = int.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Speed"]);
            }

            this.StateMachine.Update();
            LinkUtilities.UpdatePositions(this, this.Sprite.pos);

            ((AnimatedSprite)this.Sprite).flashing = this.StateMachine.isTakingDamage;

            // Play the low health beep once per second when HP is 0.5 or 1
            if ((this.HP <= 1) && (this.HP > 0) && (gameTime.TotalGameTime.TotalMilliseconds > lastLowHealthBeep + 1000))
            {
                SoundFactory.PlaySound(SoundFactory.getInstance().LowHealth);
                lastLowHealthBeep = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        public void Reset()
        {
            GameState.GetInstance().SwitchState(new GameOverState());
        }

        public void Die()
        {
            Collider.Active = false;
            LevelManager.RemoveCollider(Collider, true);
            this.StateMachine.ChangeState(new DeathLinkState());
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
            this.StateMachine.ChangeState(new IdleLinkState());
        }

        public float GetCurrentHP()
        {
            return HP;
        }

        public float GetMaxHP()
        {
            return MaxHP;
        }

        public void SetInvincible(bool invincible)
        {
            this.invincible = invincible;
        }
    }
}
