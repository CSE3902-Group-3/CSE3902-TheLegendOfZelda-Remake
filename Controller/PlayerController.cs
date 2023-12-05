using LegendOfZelda.Command.ItemMenu;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendOfZelda
{
    public class PlayerController : IController
    {
        private KeyboardMapping controllerMappings;
        private ICommands command;
        private HashSet<Keys> currKeysSet;
        private HashSet<Keys> prevKeysSet;
        private MouseState mouseState;
        private MouseState previousMouseState;
        private bool ReleasedPause;
        private PauseCommand PauseCommand;
        private GoToItemMenuCommand GoToItemMenuCommand;

        public PlayerController()
        {
            controllerMappings = new KeyboardMapping();
            prevKeysSet = new HashSet<Keys>();
            currKeysSet = new HashSet<Keys>();
            ReleasedPause = false;
            PauseCommand = new PauseCommand(GameState.PauseManager);
            GoToItemMenuCommand = new GoToItemMenuCommand();
        }

        public void Update()
        {
            prevKeysSet.Clear();
            prevKeysSet.UnionWith(currKeysSet);
            currKeysSet.Clear();
            currKeysSet.UnionWith(Keyboard.GetState().GetPressedKeys());

            KeyDownEvents();
            KeyUpEvents();
            MouseEvents();
            PauseEvents();
            ItemMenuEvents();
        }

        private void KeyDownEvents()
        {
            bool isMovingHorizontally = false;
            bool isMovingVertically = false;

            foreach (Keys key in currKeysSet)
            {
                command = controllerMappings.KeyDownCommand(key);
                if (command != null)
                {
                    if (isHorizontal(key) && !isMovingVertically)
                    {
                        command.Execute();
                        isMovingHorizontally = true;
                    }
                    else if (isVertical(key) && !isMovingHorizontally)
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
            foreach (Keys key in prevKeysSet)
            {
                if (!currKeysSet.Contains(key))
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
            RoomCycler roomCycler = RoomCycler.GetInstance();

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
        private void PauseEvents()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && ReleasedPause)
            {
                PauseCommand.Execute();
                ReleasedPause = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && !ReleasedPause)
            {
                ReleasedPause = true;
            }
        }
        private void ItemMenuEvents()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                GoToItemMenuCommand.Execute();
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