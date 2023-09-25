﻿using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    internal class MovingUpCommand : ICommands
    {
        SpriteFactory spriteFactory;
        List<AnimatedSprite> sprites;

        public void Execute()
        {
            spriteFactory = Game1.instance.spriteFactory;
            sprites = new List<AnimatedSprite>();
            sprites.Add(spriteFactory.CreateLinkWalkUpSprite());
        }
    }
}