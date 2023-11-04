﻿using LegendOfZelda.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LowerHUD : IHUD
    {
        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;
        private AnimatedSprite LowerHUDBase;

        public LowerHUD(Game1 game)
        {
            this.game = game;

            letterFactory = LetterFactory.getInstance();
            spriteFactory = SpriteFactory.getInstance();
        }

        public void LoadContent()
        {
            spriteFactory.LoadTextures();
        }

        public void Update()
        {

        }

        public void Show()
        {
            LowerHUDBase = spriteFactory.CreateLowerHUDSprite();
            LowerHUDBase.RegisterSprite();
            // The below position is for test now, should be changed to GameState.CameraController.HUDLocation later
            LowerHUDBase.UpdatePos(GameState.CameraController.mainCamera.worldPos);
        }
    }
}
