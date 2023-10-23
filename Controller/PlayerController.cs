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
        private MouseState mouseState;
        private MouseState previousMouseState;

        public PlayerController(Link Link)
        {
            link = Link;
            controllerMappings = new KeyboardMapping(link);
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

                    // Handle non-walking commands without restrictions
                    if (!isMovingHorizontally && !isMovingVertically)
                    {
                        command.Execute();
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

        private void MouseEvents()
        {
            mouseState = Mouse.GetState();
            RoomCycler roomCycler = Game1.getInstance().roomCycler;

            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && roomCycler != null)
            {
                command = new NextRoomCommand(roomCycler);
                if (command != null)
                {
                    command.Execute();
                }
            }
            else if (mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released && roomCycler != null)
            {
                command = new PreviousRoomCommand(roomCycler);
                if (command != null)
                {
                    command.Execute();
                }
            }

            previousMouseState = mouseState;
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
