using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class GoriyaBoomerang : IEnemyProjectile
    {
        ISprite GoriyaBoomerangSprite;
        Vector2 Direction;
        Vector2 Position;
        public GoriyaBoomerang(Vector2 pos, Vector2 dir)
        {
            Game1.instance.RegisterUpdateable(this);
            GoriyaBoomerangSprite = Game1.instance.spriteFactory.CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            GoriyaBoomerangSprite.UpdatePos(Position);
            if (Position.X >= Game1.instance.GraphicsDevice.Viewport.Width || Position.Y >= Game1.instance.GraphicsDevice.Viewport.Height || Position.X < 0 || Position.Y < 0)
            {
                Destroy();
            }
        }
        public void Destroy()
        {
            Game1.instance.RemoveUpdateable(this);
            Game1.instance.RemoveDrawable(GoriyaBoomerangSprite);
        }
    }
}
