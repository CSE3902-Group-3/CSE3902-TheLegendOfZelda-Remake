﻿using Microsoft.Xna.Framework;
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
            LevelMaster = LevelMaster.GetInstance();
            ResetGameState();
            RoomCycler.GetInstance();
            CameraController = CameraController.GetInstance();
        }
        public void SwitchState(IGameState state)
        {
            State = state;
        }
        public void ResetGameState()
        {
            CollisionManager = new CollisionManager();
            LevelMaster.StartLevel("level1.json");
            Link = new Link();
            LevelMaster.NavigateToRoom(0);
            PauseManager = new PauseManager();
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
