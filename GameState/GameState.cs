using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    internal class GameState : IGameState
    {
        private static GameState Instance;
        private static IGameState State;
        private static LevelMaster LevelMaster;
        public static CameraController CameraController;
        public static PauseManager PauseManager;
        public static CollisionManager CollisionManager;
        public static Link Link;

        //public enum GameStates { normalState, winState, loseState, pauseState, menuState, roomTransitionState }
        public static GameState GetInstance()
        {
            if (Instance == null)
                Instance = new GameState();
            return Instance;
        }
        private GameState()
        {
            ResetState();
        }
        public void SwitchState(IGameState state)
        {
            State = state;
        }
        public void ResetState()
        {
            CollisionManager = new CollisionManager();
            LevelMaster = LevelMaster.GetInstance();
            LevelMaster.StartLevel("level1.json");
            RoomCycler.GetInstance();
            Link = new Link();
            PauseManager = new PauseManager();
            CameraController = CameraController.GetInstance();
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
