using Microsoft.Xna.Framework;
namespace LegendOfZelda
{
    public class RoomTransitionLinkState : IState
    {
        private Link Link;
        private int LinkSpeed = int.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Speed"]);
        private int MoveFrame;
        private int CurrentFrame;
        private int TotalFrames;
        private Vector2 Dir;

        public RoomTransitionLinkState()
        {
            Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                Link.Sprite.UnregisterSprite();
            }
            switch (Link.StateMachine.currentDirection)
            {
                case Direction.up:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    Dir = new Vector2(0, -LinkSpeed);
                    MoveFrame = 68;
                    TotalFrames = 88;
                    break;
                case Direction.down:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    Dir = new Vector2(0, LinkSpeed);
                    MoveFrame = 68;
                    TotalFrames = 88;
                    break;
                case Direction.left:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    Dir = new Vector2(-LinkSpeed, 0);
                    MoveFrame = 108;
                    TotalFrames = 128;
                    break;
                case Direction.right:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    Dir = new Vector2(LinkSpeed, 0);
                    MoveFrame = 108;
                    TotalFrames = 128;
                    break;
            }
            CurrentFrame = 0;
            Link.Sprite.paused = true;
        }

        public void Execute()
        {
            if (CurrentFrame < 20)
            {
                LinkUtilities.UpdatePositions(Link, Link.Pos + Dir);
            }
            else if (CurrentFrame > MoveFrame && CurrentFrame < TotalFrames)
            {
                LinkUtilities.UpdatePositions(Link, Link.Pos + Dir);
            } else if (CurrentFrame == TotalFrames)
            {
                GameState.GetInstance().SwitchState(new NormalState());
            }
            CurrentFrame++;
        }


        public void Exit()
        {
            Link.StateMachine.canMove = true;
            Link.Velocity = int.Parse(Game1.getInstance().ReadConfig.GameConfig["Link.Speed"]);
            Link.Sprite.paused = false;
        }
    }
}
