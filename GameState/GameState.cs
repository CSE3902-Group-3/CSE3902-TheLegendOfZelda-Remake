using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class GameState : IGameState
    {
        private static GameState Instance;
        private static IGameState State;
        private static LevelMaster LevelMaster;
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
            Link = Link.getInstance();
            LevelMaster = LevelMaster.GetInstance();
            LevelMaster.StartLevel("level1.json");
            PauseManager = new PauseManager();
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

            // this portion solely for testing with winning state
            if (gameTime.TotalGameTime.TotalMilliseconds > 3000 && !AlreadySwitched)
            {
                SwitchState(new WinningState());
                AlreadySwitched = true;
            }
        }
        public void Draw()
        {
            State.Draw();
        }
    }
}
