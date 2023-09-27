using LegendOfZelda;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //Class completed last minute by Michael in order to meet functionality check. This is not clean nor intended to be permanent. Original author still needs to come back and finish the class themself.
    internal class PlayerController : IController
    {
        //private Dictionary<Keys, ICommands> controllerMappings;
        private KeyboardMapping controllerMappings;
        private Link link;
        private ICommands command;
        /*
        private KeyboardState currState;
        private KeyboardState prevState;
        //private Dictionary<Keys, bool> keyState;
        */
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
            /*
            Keys[] currKeys= currState.GetPressedKeys();
            Keys[] prevKeys = prevState.GetPressedKeys();
            */

            foreach (Keys key in currKeys)
            {
                command = controllerMappings.GetCommand(key);
                if (command != null)
                {
                    command.Execute();
                }
            }
        }

        private void KeyUpEvents()
        {
            /*
            Keys[] currKeys = currState.GetPressedKeys();
            Keys[] prevKeys = prevState.GetPressedKeys();
            */

            foreach (Keys key in prevKeys)
            {
                if (!currKeys.Contains(key))
                {
                    command = controllerMappings.GetUpCommand(key);
                    if (command != null)
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}
