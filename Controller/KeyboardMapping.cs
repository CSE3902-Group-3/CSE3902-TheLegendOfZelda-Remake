using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class KeyboardMapping
    {
        private Dictionary<Keys, ICommands> KeyDownMapping;
        private Dictionary<Keys, ICommands> keyUpMappings;
        public KeyboardMapping()
        {
            keyUpMappings = new Dictionary<Keys, ICommands>
            {
                { Keys.Q, new QuitCommand() },
                { Keys.R, new ResetCommand() },
                { Keys.K, new PreviousPalletCommand() },
                { Keys.L, new NextPalletCommand() },
                { Keys.W, new ToIdleCommand() },
                { Keys.A, new ToIdleCommand() },
                { Keys.S, new ToIdleCommand() },
                { Keys.D, new ToIdleCommand() },
                { Keys.Up, new ToIdleCommand() },
                { Keys.Left, new ToIdleCommand() },
                { Keys.Down, new ToIdleCommand() },
                { Keys.Right, new ToIdleCommand() }
            };

            KeyDownMapping = new Dictionary<Keys, ICommands>
            {
                { Keys.W, new MovingUpCommand() },
                { Keys.Up, new MovingUpCommand() },
                { Keys.A, new MovingLeftCommand() },
                { Keys.Left, new MovingLeftCommand() },
                { Keys.S, new MovingDownCommand() },
                { Keys.Down, new MovingDownCommand() },
                { Keys.D, new MovingRightCommand() },
                { Keys.Right, new MovingRightCommand() },
                { Keys.X, new UseSecondaryItemCommand() },
                { Keys.Z, new PrimaryAttackCommand() },
                { Keys.N, new PrimaryAttackCommand() }
            };
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
