﻿using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MapHUD : IHUD
    {
        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;
        private AnimatedSprite MapHUDBase;

        public MapHUD(Game1 game)
        {
            this.game = game;

            spriteFactory = SpriteFactory.getInstance();
            letterFactory = LetterFactory.GetInstance();
        }

        public void LoadContent()
        {
            MapHUDBase = spriteFactory.CreateMapHUDSprite();
        }

        public void Update(GameTime gametime)
        {

        }

        public void Show()
        {

        }
    }
}
