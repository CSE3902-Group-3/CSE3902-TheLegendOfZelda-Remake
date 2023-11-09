using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static RoomCycler RoomCycler;

        // testing
        private static bool AlreadySwitched = false;
        //public enum GameStates { normalState, winState, loseState, pauseState, menuState, roomTransitionState }
        public static GameState GetInstance()
        {
            if (Instance == null)
                Instance = new GameState();
            return Instance;
        }
        private GameState()
        {
            CollisionManager = new CollisionManager();
            LevelMaster = LevelMaster.GetInstance();
            LevelMaster.StartLevel("level1.json");
            Link = Link.getInstance();
            PauseManager = new PauseManager();
            CameraController = CameraController.GetInstance();
            State = new NormalState();
        }
        public void SwitchState(IGameState state)
        {
            State = state;
        }
        public void ResetState()
        {
            Instance = new GameState();
            // need a way to reset link
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);

            // Uncomment the part below to test game over screen
            /*if (gameTime.TotalGameTime.TotalMilliseconds > 3000 && !AlreadySwitched)
            {
                SwitchState(new GameOverState());
                AlreadySwitched = true;
            }*/
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            State.Draw(_spriteBatch);
        }
    }
}
