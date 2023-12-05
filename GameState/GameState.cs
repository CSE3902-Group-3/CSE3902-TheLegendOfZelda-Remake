using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameState : IGameState
    {
        private static GameState Instance;
        private static IGameState State;
        public static LevelManager LevelManager { get; private set; }
        public static CameraController CameraController { get; private set; }
        public static PauseManager PauseManager { get; private set; }
        public static CollisionManager CollisionManager { get; set; }
        public static Link Link { get; set; }
        public static LowerHUD LowerHUD { get; private set; }
        public static InventoryHUD InventoryHUD { get; private set; }
        public static MapHUD MapHUD { get; private set; }
        public static GameOverMenuSelector Selector { get; private set; }
        public static IController PlayerController { get; private set; }
        public static IController ItemMenuController { get; private set; }
        public static IController CheatCodeController { get; set; }
        public static GameState GetInstance()
        {
            if (Instance == null)
                Instance = new GameState();
            return Instance;
        }
        private GameState()
        {
            LevelManager = LevelManager.GetInstance();
            CollisionManager = new CollisionManager();
            CameraController = CameraController.GetInstance();
            BackgroundGenerator.GenerateMenuBackgrounds();
            Selector = new GameOverMenuSelector();
            PauseManager = new PauseManager();
            State = new StartState();
            PlayerController = new PlayerController();
            ItemMenuController = new ItemMenuController();
        }
        public void SwitchState(IGameState state)
        {
            State = state;
        }
        public void SetToNormal()
        {
            State = new NormalState();
        }
        public void ResetGameState()
        {
            State = new LevelTransitionState(LevelManager.CurrentLevel);
        }
        public void GameOverContinue()
        {
            Link = new Link();
            LevelManager.SnapToRoom(0);
            LinkUtilities.UpdatePositions(Link, LinkUtilities.originalLinkPosition);
            CameraController.ChangeMenu(Menu.Item);
            State = new NormalState();
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            State.Draw(_spriteBatch);
        }
    }
}