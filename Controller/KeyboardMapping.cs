using LegendOfZelda.Command;
using LegendOfZelda.Command.Link;
using LegendOfZelda.Command.TestUse;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Controller
{
    internal class KeyboardMapping
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Game1 game;

        public KeyboardMapping(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommands>();

            controllerMappings.Add(Keys.Q, new QuitCommand(game));
            controllerMappings.Add(Keys.R, new ResetCommand());

            controllerMappings.Add(Keys.W, new MovingUpCommand());
            controllerMappings.Add(Keys.Up, new MovingUpCommand());
            controllerMappings.Add(Keys.A, new MovingLeftCommand());
            controllerMappings.Add(Keys.Left, new MovingLeftCommand());
            controllerMappings.Add(Keys.S, new MovingDownCommand());
            controllerMappings.Add(Keys.Down, new MovingDownCommand());
            controllerMappings.Add(Keys.D, new MovingRightCommand());
            controllerMappings.Add(Keys.Right, new MovingRightCommand());
            controllerMappings.Add(Keys.Z, new PrimaryAttackCommand());
            controllerMappings.Add(Keys.N, new SecondaryAttackCommand());

            controllerMappings.Add(Keys.E, new DamageCommand());
            controllerMappings.Add(Keys.D1, new UseItemCommand());
            controllerMappings.Add(Keys.T, new PreviousBlockCommand());
            controllerMappings.Add(Keys.Y, new NextBlockCommand());
            controllerMappings.Add(Keys.U, new PreviousItemCommand());
            controllerMappings.Add(Keys.I, new NextItemCommand());
            controllerMappings.Add(Keys.O, new PreviousEnemyCommand());
            controllerMappings.Add(Keys.P, new NextEnemyCommand());

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
    }
}
