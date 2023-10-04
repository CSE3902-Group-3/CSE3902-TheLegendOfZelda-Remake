using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class GoriyaBoomerang : IEnemyProjectile
    {
        private readonly Game1 game;
        private readonly ISprite GoriyaBoomerangSprite;
        private Vector2 Direction;
        private Vector2 Position;
        public GoriyaBoomerang(Vector2 pos, Vector2 dir)
        {
            Game1.getInstance().RegisterUpdateable(this);
            GoriyaBoomerangSprite = SpriteFactory.getInstance().CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            GoriyaBoomerangSprite.UpdatePos(Position);
            if (Position.X >= Game1.getInstance().GraphicsDevice.Viewport.Width || Position.Y >= Game1.getInstance().GraphicsDevice.Viewport.Height || Position.X < 0 || Position.Y < 0)
            {
                Destroy();
            }
        }
        public void Destroy()
        {
            Game1.getInstance().RemoveUpdateable(this);
            Game1.getInstance().RemoveDrawable(GoriyaBoomerangSprite);
        }
    }
}
