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
        public static CollisionManager CollisionManager { get; private set; }
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
            LevelMaster.StartLevel("level1.json");
            Link = new Link();
            LevelMaster.SnapToRoom(0);
            PauseManager = new PauseManager();
            BackgroundGenerator.GenerateMenuBackgrounds();
            State = new StartState();
            RoomCycler.GetInstance();
            CameraController = CameraController.GetInstance();
            lowerHUD = LowerHUD.GetInstance();
            inventoryHUD = InventoryHUD.GetInstance();
            mapHUD = MapHUD.GetInstance();
            PlayerController = new PlayerController(Link);
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
            CollisionManager = new CollisionManager();
            CameraController.Reset();
            CameraController.ChangeMenu(Menu.Item);
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