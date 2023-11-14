using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class KeyboardMapping
    {
        private Dictionary<Keys, ICommands> KeyDownMapping;
        private Dictionary<Keys, ICommands> keyUpMappings;

        private Game1 game;

        public KeyboardMapping(Link link)
        {
            this.game = Game1.getInstance();

            KeyDownMapping = new Dictionary<Keys, ICommands>();
            keyUpMappings = new Dictionary<Keys, ICommands>();

            keyUpMappings.Add(Keys.Q, new QuitCommand());
            keyUpMappings.Add(Keys.R, new ResetCommand(link));

            KeyDownMapping.Add(Keys.W, new MovingUpCommand(link));
            KeyDownMapping.Add(Keys.Up, new MovingUpCommand(link));
            KeyDownMapping.Add(Keys.A, new MovingLeftCommand(link));
            KeyDownMapping.Add(Keys.Left, new MovingLeftCommand(link));
            KeyDownMapping.Add(Keys.S, new MovingDownCommand(link));
            KeyDownMapping.Add(Keys.Down, new MovingDownCommand(link));
            KeyDownMapping.Add(Keys.D, new MovingRightCommand(link));
            KeyDownMapping.Add(Keys.Right, new MovingRightCommand(link));

            KeyDownMapping.Add(Keys.B, new UseSecondaryItemCommand());

            keyUpMappings.Add(Keys.W, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.A, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.S, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.D, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Up, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Left, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Down, new ToIdleCommand(link));
            keyUpMappings.Add(Keys.Right, new ToIdleCommand(link));
            KeyDownMapping.Add(Keys.Z, new PrimaryAttackCommand(link));
            KeyDownMapping.Add(Keys.N, new PrimaryAttackCommand(link));

            //KeyDownMapping.Add(Keys.M, new WinningCommand());

        }

        public ICommands KeyDownCommand(Keys key)
        {
            if (KeyDownMapping.ContainsKey(key))
            {
                return KeyDownMapping[key];
            }
            else
            {
                return null;
            }
        }

        public ICommands KeyUpCommand(Keys key)
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
