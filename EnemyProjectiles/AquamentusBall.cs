using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class AquamentusBall : IEnemyProjectile
    {
        private ISprite AquamentusBallSprite;
        private Vector2 Position;
        private Vector2 Direction;
        public AquamentusBall(Vector2 pos, Vector2 dir)
        {
            Game1.getInstance().RegisterUpdateable(this);
            AquamentusBallSprite = Game1.getInstance().spriteFactory.CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction;
            AquamentusBallSprite.UpdatePos(Position);
            if (Position.X >= Game1.getInstance().GraphicsDevice.Viewport.Width || Position.Y >= Game1.getInstance().GraphicsDevice.Viewport.Height || Position.X < 0 || Position.Y < 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Game1.getInstance().RemoveUpdateable(this);
            Game1.getInstance().RemoveDrawable(AquamentusBallSprite);
        }

    }
}
