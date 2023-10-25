﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LinkCollisionWithBlock
    {
        public static void HandleCollisionWithWall(Direction direction, Rectangle overlapRectangle)
        {
            Vector2 newPosition = Game1.getInstance().link.sprite.pos;

            switch (direction)
            {
                case Direction.up:
                    newPosition.Y += overlapRectangle.Height;
                    break;
                case Direction.down:
                    newPosition.Y -= overlapRectangle.Height;
                    break;
                case Direction.right:
                    newPosition.X -= overlapRectangle.Width;
                    break;
                case Direction.left:
                    newPosition.X += overlapRectangle.Width;
                    break;
            }

            LinkUtilities.UpdatePositions((Link)Game1.getInstance().link, newPosition);
            ((Link)Game1.getInstance().link).velocity = 0;
        }
    }
}