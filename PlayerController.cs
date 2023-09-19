using LegendOfZelda.Command;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class PlayerController : IController
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Game1 game;
        private ICommands command;

        public PlayerController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommands>();
            controllerMappings.Add(Keys.W, new MovingUpCommand());
            controllerMappings.Add(Keys.A, new MovingLeftCommand());
            controllerMappings.Add(Keys.S, new MovingDownCommand());
            controllerMappings.Add(Keys.D, new MovingRightCommand());
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    command = controllerMappings[key];
                    command.Execute();
                }
            }
        }
    }
}
