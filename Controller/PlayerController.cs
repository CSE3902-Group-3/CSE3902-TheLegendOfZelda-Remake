using LegendOfZelda.Command.TestUse;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace LegendOfZelda
{
    internal class PlayerController : IController
    {
        private KeyboardMapping controllerMappings;
        private MouseState mouseState;
        private Link link;
        private ICommands command;
        private Keys[] currKeys;
        private Keys[] prevKeys;

        public PlayerController(Link Link)
        {
            link = Link;
            controllerMappings = new KeyboardMapping(link);
            mouseState = new MouseState();
            prevKeys = Array.Empty<Keys>();
            currKeys = Array.Empty<Keys>();
            
            //keyState = new Dictionary<Keys, bool>();
        }

        public void Update()
        {
            prevKeys = currKeys;
            currKeys = Keyboard.GetState().GetPressedKeys();

            KeyDownEvents();
            KeyUpEvents();
            MouseEvents();
        }

        private void MouseEvents()
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                command = new NextRoomCommand(Game1.getInstance().roomCycler);
                if (command != null)
                {
                    command.Execute();
                }
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                command = new PreviousRoomCommand(Game1.getInstance().roomCycler);
                if (command != null)
                {
                    command.Execute();
                }
            }
        }

        private void KeyDownEvents()
        {
            bool isMovingHorizontally = false;
            bool isMovingVertically = false;

            foreach (Keys key in currKeys)
            {
                command = controllerMappings.KeyDownCommand(key);
                if (command != null)
                {
                    if (isHorizontal(key) && !isMovingVertically)
                    {
                        command.Execute();
                        isMovingHorizontally = true;
                    }
                    else if(isVertical(key) && !isMovingHorizontally)
                    {
                        command.Execute();
                        isMovingVertically = true;
                    }
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

        private Boolean isHorizontal(Keys key)
        {
            return key == Keys.A || key == Keys.Left || key == Keys.D || key == Keys.Right;
        }

        private Boolean isVertical(Keys key)
        {
            return key == Keys.W || key == Keys.Up || key == Keys.S || key == Keys.Down;
        } 
    }
}
