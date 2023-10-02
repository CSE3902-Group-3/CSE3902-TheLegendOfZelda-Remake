﻿using LegendOfZelda;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
    internal class KeyboardMapping
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Dictionary<Keys, ICommands> keyUpMappings;

        private Game1 game;

        public KeyboardMapping(Link link)
        {
            this.game = Game1.getInstance();
            controllerMappings = new Dictionary<Keys, ICommands>();
            keyUpMappings = new Dictionary<Keys, ICommands>();

            keyUpMappings.Add(Keys.Q, new QuitCommand());
            keyUpMappings.Add(Keys.R, new ResetCommand());

            controllerMappings.Add(Keys.W, new MovingUpCommand(link));
            controllerMappings.Add(Keys.Up, new MovingUpCommand(link));
            controllerMappings.Add(Keys.A, new MovingLeftCommand(link));
            controllerMappings.Add(Keys.Left, new MovingLeftCommand(link));
            controllerMappings.Add(Keys.S, new MovingDownCommand(link));
            controllerMappings.Add(Keys.Down, new MovingDownCommand(link));
            controllerMappings.Add(Keys.D, new MovingRightCommand(link));
            controllerMappings.Add(Keys.Right, new MovingRightCommand(link));
            keyUpMappings.Add(Keys.W, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.A, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.S, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.D, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Up, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Left, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Down, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Right, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Z, new PrimaryAttackCommand(link));
            keyUpMappings.Add(Keys.N, new PrimaryAttackCommand(link));

            keyUpMappings.Add(Keys.E, new DamageCommand(link));
            keyUpMappings.Add(Keys.D1, new UseItemCommand(link));
            keyUpMappings.Add(Keys.T, new PreviousBlockCommand(game.blockCycler));
            keyUpMappings.Add(Keys.Y, new NextBlockCommand(game.blockCycler));
            keyUpMappings.Add(Keys.U, new PreviousItemCommand(game.itemCycler));
            keyUpMappings.Add(Keys.I, new NextItemCommand(game.itemCycler));
            keyUpMappings.Add(Keys.O, new PreviousEnemyCommand(game.enemyCycler));
            keyUpMappings.Add(Keys.P, new NextEnemyCommand(game.enemyCycler));

        }

        public ICommands GetCommand(Keys key)
        {
            if (controllerMappings.ContainsKey(key))
            {
                return controllerMappings[key];
            }
            else
            {
                return null;
            }
        }

        public ICommands GetUpCommand(Keys key)
        {
            if (keyUpMappings.ContainsKey(key))
            {
                return keyUpMappings[key];
            }
            else
            {
                return null;
            }
        }
    }
}
