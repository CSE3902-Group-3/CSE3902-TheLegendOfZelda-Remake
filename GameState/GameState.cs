using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameState : IGameState
    {
        private static GameState Instance;
        private static IGameState State;
        private static LevelMaster LevelMaster;
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
            LevelMaster = LevelMaster.GetInstance();
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
            LinkUtilities.UpdatePositions(Link, LinkUtilities.originalLinkPosition);
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
            LevelMaster.StartLevel("level1.json");
            Link = new Link();
            LevelMaster.SnapToRoom(1);
            PauseManager = new PauseManager();
            BackgroundGenerator.GenerateMenuBackgrounds();
            State = new NormalState();
            CameraController.Reset();
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
            SwitchState(new NormalState());
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