using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameState : IGameState
    {
        private static GameState Instance;
        private static IGameState State;
        private static LevelManager LevelMaster;
        public static CameraController CameraController;
        public static PauseManager PauseManager;
        public static CollisionManager CollisionManager;
        public static Link Link;
        public static LowerHUD lowerHUD;
        public static InventoryHUD inventoryHUD;
        public static MapHUD mapHUD;
        public static IController PlayerController;
        public static IController ItemMenuController;
        public static GameState GetInstance()
        {
            if (Instance == null)
                Instance = new GameState();
            return Instance;
        }
        private GameState()
        {
            LevelMaster = LevelManager.GetInstance();
            CollisionManager = new CollisionManager();
            LevelMaster.StartLevel("level1.json");
            Link = new Link();
            LevelMaster.SnapToRoom(1);
            PauseManager = new PauseManager();
            BackgroundGenerator.GenerateMenuBackgrounds();
            State = new StartState();
            RoomCycler.GetInstance();
            CameraController = CameraController.GetInstance();
            lowerHUD = LowerHUD.GetInstance();
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
            CameraController.Reset();
            CollisionManager = new CollisionManager();
            LevelMaster.StartLevel("level1.json");
            Link = new Link();
            LevelMaster.SnapToRoom(1);
            PauseManager = new PauseManager();
            BackgroundGenerator.GenerateMenuBackgrounds();
            State = new NormalState();
            PlayerController = new PlayerController(Link);
            ItemMenuController = new ItemMenuController();
            LinkUtilities.UpdatePositions(Link, LinkUtilities.originalLinkPosition);
        }
        public void GameOverContinue()
        {
            CollisionManager = new CollisionManager();
            Link = new Link();
            LevelMaster.SnapToRoom(1);
            PlayerController = new PlayerController(Link);
            CameraController.Reset();
            CameraController.ChangeMenu(Menu.Item);
            SwitchState(new NormalState());
            LinkUtilities.UpdatePositions(Link, LinkUtilities.originalLinkPosition);
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