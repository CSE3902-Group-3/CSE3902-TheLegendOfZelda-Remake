using LegendOfZelda.Command;
using LegendOfZelda.Command.TestUse;
using LegendOfZelda.Command.Link;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Controller
{
    internal class PlayerController : IController
    {
        //private Dictionary<Keys, ICommands> controllerMappings;
        private KeyboardMapping controllerMappings;
        private IPlayer link;
        private ICommands command;
        private KeyboardState currState;
        private KeyboardState prevState;
        //private Dictionary<Keys, bool> keyState;

        public PlayerController(Game1 game, IPlayer Link)
        {
            link = Link;
            controllerMappings = new KeyboardMapping(game, link);
            
            //keyState = new Dictionary<Keys, bool>();a
        }

        public void Update()
        {
            currState = Keyboard.GetState();

            KeyDownEvents();
            KeyUpEvents();

            prevState = currState;
            /*
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {

                if (keyboardState.IsKeyDown(key))
                {
                    // Check if the key is not in the keyState dictionary or if it was not pressed in the previous frame.
                    if (!keyState.ContainsKey(key) || !keyState[key])
                    {
                        command = controllerMappings.GetCommand(key);
                        if (command != null)
                        {
                            command.Execute();
                        }
                    }

                    // Update the key state to indicate it's currently pressed.
                    keyState[key] = true;
                }
                else
                {
                    keyState[key] = false;
                }
            }
            */
        }

        private void KeyDownEvents()
        {
            Keys[] currKeys= currState.GetPressedKeys();
            Keys[] prevKeys = prevState.GetPressedKeys();

            foreach (Keys key in currKeys)
            {
                if (!prevKeys.Contains(key))
                {
                    command = controllerMappings.GetCommand(key);
                    if (command != null)
                    {
                        command.Execute();
                    }
                }
            }
        }

        private void KeyUpEvents()
        {
            Keys[] currKeys = currState.GetPressedKeys();
            Keys[] prevKeys = prevState.GetPressedKeys();

            foreach (Keys key in prevKeys)
            {
                if (!prevKeys.Contains(key))
                {
                    command = new IdleCommand(link);
                    command.Execute();
                }
            }
        }
    }
}
