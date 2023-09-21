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
        private Game1 game;
        private KeyboardMapping controllerMappings;
        private ICommands command;
        private Dictionary<Keys, bool> keyState;

        public PlayerController(Game1 game)
        {
            controllerMappings = new KeyboardMapping(game);

            keyState = new Dictionary<Keys, bool>();
        }

        public void Update()
        {

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
        }
    }
}
