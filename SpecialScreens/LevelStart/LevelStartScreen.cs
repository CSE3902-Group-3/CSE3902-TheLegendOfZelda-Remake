using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LevelStartScreen : IUpdateable
    {
        private Vector2 CameraPos;
        private int Counter;
        private double TimeDiff = 200;
        private double StartTime;
        private Game1 Game1 = Game1.getInstance();
        private List<AnimatedSprite> LevelText;
        private LetterFactory LetterFactory = LetterFactory.GetInstance();
        private int LetterWidth = 30;
        public LevelStartScreen(int levelNumber)
        {
            CameraPos = LevelManager.CurrentRoomPosition + new Vector2(0, Game1.getInstance().GraphicsDevice.Viewport.Height);
            CameraController.GetInstance().mainCamera.worldPos = CameraPos;
            ConstructLevelText(levelNumber);
            Counter = 0;
        }
        private void ConstructLevelText(int levelNumber)
        {
            LevelText = new List<AnimatedSprite>()
            {
                LetterFactory.GetLetterSprite('L'),
                LetterFactory.GetLetterSprite('E'),
                LetterFactory.GetLetterSprite('V'),
                LetterFactory.GetLetterSprite('E'),
                LetterFactory.GetLetterSprite('L'),
                LetterFactory.GetBlankSprite(),
                LetterFactory.GetLetterSprite(levelNumber)
            };
        }
        private void TearDownStartingLevelText()
        {
            for (int i = LevelText.Count - 1; i >= 0; i--)
            {
                LevelText[i].UnregisterSprite();
            }
        }
        public void Update(GameTime gameTime)
        {
            if (DetermineIfStageChange(gameTime))
            {
                switch (Counter)
                {
                    case 0:
                        StartTime = gameTime.TotalGameTime.TotalMilliseconds;
                        Counter++;
                        break;
                    case 1:
                        IncrementLetterStage();
                        break;
                    case 2:
                        IncrementLetterStage();
                        break;
                    case 3:
                        IncrementLetterStage();
                        break;
                    case 4:
                        IncrementLetterStage();
                        break;
                    case 5:
                        IncrementLetterStage();
                        break;
                    case 6:
                        LevelText[Counter - 1].UpdatePos(DetermineLetterPosition());
                        IncrementStage();
                        break;
                    case 7:
                        IncrementLetterStage();
                        break;
                    case 8:
                        CameraPanUpStage();
                        break;
                }
            }
        }
        public bool DetermineIfStageChange(GameTime gameTime)
        {
            return CalculateTimeDiffFromStart(gameTime) > TimeDiff * Counter;
        }
        private double CalculateTimeDiffFromStart(GameTime gameTime)
        {
            return gameTime.TotalGameTime.TotalMilliseconds - StartTime;
        }
        private void IncrementLetterStage()
        {
            LevelText[Counter - 1].UpdatePos(DetermineLetterPosition());
            IncrementStage();
            SoundFactory.PlaySound(SoundFactory.getInstance().Text);
        }
        private Vector2 DetermineLetterPosition()
        {
            return CameraPos + new Vector2(Game1.GraphicsDevice.Viewport.Width * .4f + (Counter - 1) * LetterWidth, Game1.GraphicsDevice.Viewport.Height * .4f);
        }
        private void CameraPanUpStage()
        {
            LevelManager.GetInstance().TransitionToStartingRoom(AfterCameraPanUp);
            IncrementStage();
        }
        private void AfterCameraPanUp()
        {
            TearDownStartingLevelText();
            GameState.GetInstance().SwitchState(new NormalState());
        }
        private void IncrementStage()
        {
            Counter++;
        }
    }
}