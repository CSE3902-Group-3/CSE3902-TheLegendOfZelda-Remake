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
            game = Game1.instance;
            game.RegisterUpdateable(this);
            GoriyaBoomerangSprite = game.spriteFactory.CreateBoomerangSprite();
            Position = pos;
            Direction = dir;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            GoriyaBoomerangSprite.UpdatePos(Position);
            if (Position.X >= game.GraphicsDevice.Viewport.Width || Position.Y >= game.GraphicsDevice.Viewport.Height || Position.X < 0 || Position.Y < 0)
            {
                Destroy();
            }
        }
        public void Destroy()
        {
            game.RemoveUpdateable(this);
            game.RemoveDrawable(GoriyaBoomerangSprite);
        }
    }
}
