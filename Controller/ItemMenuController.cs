using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendOfZelda
{
    public class ItemMenuController : IController
    {
        private Dictionary<Keys, ICommands> KeyCommands;

        private Keys[] currKeys;
        private Keys[] prevKeys;

        public ItemMenuController()
        {
            prevKeys = Array.Empty<Keys>();
            currKeys = Array.Empty<Keys>();

            KeyCommands = new Dictionary<Keys, ICommands>();
            KeyCommands.Add(Keys.M, new ReturnFromItemMenuCommand());
            KeyCommands.Add(Keys.Up, new SelectUpCommand());
            KeyCommands.Add(Keys.W, new SelectUpCommand());
            KeyCommands.Add(Keys.Down, new SelectDownCommand());
            KeyCommands.Add(Keys.S, new SelectDownCommand());
            KeyCommands.Add(Keys.Left, new SelectLeftCommand());
            KeyCommands.Add(Keys.A, new SelectDownCommand());
            KeyCommands.Add(Keys.Right, new SelectRightCommand());
            KeyCommands.Add(Keys.D, new SelectRightCommand());
        }

        public void Update()
        {
            prevKeys = currKeys;
            currKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in currKeys)
            {
                if (!prevKeys.Contains(key))
                {
                    ICommands command = null;
                    if (KeyCommands.ContainsKey(key))
                        command = KeyCommands[key];
                    if (command != null)
                        command.Execute();
                }
            }
        }
    }
}
