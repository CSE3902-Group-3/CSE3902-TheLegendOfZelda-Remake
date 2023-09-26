using LegendOfZelda.Command;
using LegendOfZelda.Command.Link;
using LegendOfZelda.Command.TestUse;
using LegendOfZelda.Player;
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
        private Dictionary<Keys, ICommands> keyUpMappings;

        private Game1 game;

        public KeyboardMapping(Game1 game, Link link)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommands>();
            keyUpMappings = new Dictionary<Keys, ICommands>();

            keyUpMappings.Add(Keys.Q, new QuitCommand(game));
            keyUpMappings.Add(Keys.R, new ResetCommand());

            controllerMappings.Add(Keys.W, new MovingUpCommand(link));
            controllerMappings.Add(Keys.Up, new MovingUpCommand(link));
            controllerMappings.Add(Keys.A, new MovingLeftCommand(link));
            controllerMappings.Add(Keys.Left, new MovingLeftCommand(link));
            controllerMappings.Add(Keys.S, new MovingDownCommand(link));
            controllerMappings.Add(Keys.Down, new MovingDownCommand(link));
            controllerMappings.Add(Keys.D, new MovingRightCommand(link));
            controllerMappings.Add(Keys.Right, new MovingRightCommand(link));
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
