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
        public static CollisionManager CollisionManager;
        public static Link Link;
        public static RoomCycler RoomCycler;
        //public enum GameStates { normalState, winState, loseState, pauseState, menuState, roomTransitionState }
        public static GameState GetInstance()
        {
            if (Instance == null)
                Instance = new GameState();
            return Instance;
        }
        private GameState()
        {
            State = new NormalState();
            CollisionManager = new CollisionManager();
            Link = Link.getInstance();
            LevelMaster = LevelMaster.GetInstance();
            LevelMaster.StartLevel("level1.json");
            RoomCycler = new RoomCycler(LevelMaster);
        }
        public void SwitchState(GameState state)
        {
            State = state;
        }
        public void ResetState(GameState state)
        {
            Instance = new GameState();
            // need a way to reset link
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }
        public void Draw()
        {
            State.Draw();
        }
    }
}
