using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class BoomerangProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private float speed = 10;
        private const float accel = .5f;
        private const float dist = 200;
        private Vector2 pos;
        private Vector2 dir;
        private Vector2 target;
        private bool returning = false;
        private IPlayer player;
        public BoomerangProjectile(Vector2 position, Vector2 direction, IPlayer player)
        {
            game = Game1.getInstance();
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            pos = position;
            this.player = player;

            dir = direction;
            dir.Normalize();

            target = pos + dir * dist;

            sprite = spriteFactory.CreateBoomerangSprite();
            sprite.UpdatePos(position);

            game.RegisterUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            //State pattern would work better here but would be overkill for such a small class
            if (returning)
            {
                dir = player.pos - pos;
                if(dir.Length() < speed)
                {
                    Destroy();
                }
                else
                {
                    dir.Normalize();
                    pos += dir * speed;
                    speed += accel;
                    sprite.UpdatePos(pos);
                }
            }
            else
            {
                if (speed <= 0){
                    returning = true;
                } else
                {
                    pos += speed * dir;
                    speed -= accel;
                }
                sprite.UpdatePos(pos);
            }
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }
    }
}
