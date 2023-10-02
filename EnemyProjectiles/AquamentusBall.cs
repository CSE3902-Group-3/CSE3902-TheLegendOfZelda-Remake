using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AquamentusBall : IEnemyProjectile
    {
        private readonly ISprite AquamentusBallSprite;
        private Vector2 Position;
        private Vector2 Direction;
        public AquamentusBall(Vector2 pos, Vector2 dir)
        {
            Game1.instance.RegisterUpdateable(this);
            AquamentusBallSprite = Game1.instance.spriteFactory.CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction;
            AquamentusBallSprite.UpdatePos(Position);
            if (Position.X >= Game1.instance.GraphicsDevice.Viewport.Width || Position.Y >= Game1.instance.GraphicsDevice.Viewport.Height || Position.X < 0 || Position.Y < 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Game1.instance.RemoveUpdateable(this);
            Game1.instance.RemoveDrawable(AquamentusBallSprite);
        }

    }
}
