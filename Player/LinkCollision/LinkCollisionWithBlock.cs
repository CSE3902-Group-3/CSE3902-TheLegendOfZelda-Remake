using Microsoft.Xna.Framework;
namespace LegendOfZelda
{
    public class LinkCollisionWithBlock
    {
        public static void HandleCollisionWithWall(Direction direction, Rectangle overlapRectangle)
        {

            if (GameState.Link.StateMachine.CurrentState is KnockBackLinkState)
            {
                GameState.Link.StateMachine.ChangeState(new IdleLinkState());
                GameState.Link.StateMachine.isKnockedBack = false;
                return;
            }

            Vector2 newPosition = GameState.Link.Sprite.pos;

            switch (direction)
            {
                case Direction.up:
                    newPosition.Y += overlapRectangle.Height;
                    break;
                case Direction.down:
                    newPosition.Y -= overlapRectangle.Height;
                    break;
                case Direction.right:
                    newPosition.X -= overlapRectangle.Width;
                    break;
                case Direction.left:
                    newPosition.X += overlapRectangle.Width;
                    break;
            }

            LinkUtilities.UpdatePositions(GameState.Link, newPosition);
            GameState.Link.Velocity = 0;
        }
    }
}
