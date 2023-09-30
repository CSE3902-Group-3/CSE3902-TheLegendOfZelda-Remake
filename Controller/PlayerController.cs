using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace LegendOfZelda
{
    internal class PlayerController : IController
    {
        private KeyboardMapping controllerMappings;
        private Link link;
        private ICommands command;
        private Keys[] currKeys;
        private Keys[] prevKeys;

        public PlayerController(Game1 game, Link Link)
        {
            link = Link;
            controllerMappings = new KeyboardMapping(game, link);
            prevKeys = Array.Empty<Keys>();
            currKeys = Array.Empty<Keys>();
            
            //keyState = new Dictionary<Keys, bool>();a
        }

        public void Update()
        {
            prevKeys = currKeys;
            currKeys = Keyboard.GetState().GetPressedKeys();

            KeyDownEvents();
            KeyUpEvents();
        }

        private void KeyDownEvents()
        {
            foreach (Keys key in currKeys)
            {
                command = controllerMappings.KeyDownCommand(key);
                if (command != null)
                {
                    command.Execute();
                }
            }
        }

        private void KeyUpEvents()
        {
            foreach (Keys key in prevKeys)
            {
                if (!currKeys.Contains(key))
                {
                    command = controllerMappings.KeyUpCommand(key);
                    if (command != null)
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}
