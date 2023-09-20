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

namespace LegendOfZelda
{
    internal class PlayerController : IController
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Game1 game;
        private ICommands command;
        private Dictionary<Keys, bool> keyState;

        public PlayerController(Game1 game)
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


            keyState = new Dictionary<Keys, bool>();
        }

        public void Update()
        {

            KeyboardState keyboardState = Keyboard.GetState();

            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (keyboardState.IsKeyDown(key))
                {
                    // Check if the key is not in the keyState dictionary or if it was not pressed in the previous frame.
                    if (!keyState.ContainsKey(key) || !keyState[key])
                    {
                        if (controllerMappings.ContainsKey(key))
                        {
                            command = controllerMappings[key];
                            command.Execute();
                        }
                    }

                    // Update the key state to indicate it's currently pressed.
                    keyState[key] = true;
                }
                else
                {
                    // If the key is not pressed, mark it as released in the keyState dictionary.
                    keyState[key] = false;
                }
            }
        }
    }
}
