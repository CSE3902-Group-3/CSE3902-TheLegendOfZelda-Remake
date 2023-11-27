﻿using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class CheatCodeController : IController
	{
		private bool ReleasedKey;
		private RestoreHealthCommand restoreHealthCommand;
		private AddRupeeCommand addRupeeCommand;
		private KillEnemiesCommand killEnemiesCommand;

		public CheatCodeController()
		{
			ReleasedKey = false;
			restoreHealthCommand = new RestoreHealthCommand();
			addRupeeCommand = new AddRupeeCommand();
			killEnemiesCommand = new KillEnemiesCommand();
		}

		public void Update()
		{
            if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.H) && ReleasedKey)
            {
				restoreHealthCommand.Execute();
                ReleasedKey = false;
            }
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.P) && ReleasedKey)
			{
				addRupeeCommand.Execute();
				ReleasedKey = false;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.K) && ReleasedKey)
			{
				killEnemiesCommand.Execute();
				ReleasedKey = false;
			}

            if (Keyboard.GetState().IsKeyUp(Keys.C) && Keyboard.GetState().IsKeyUp(Keys.H) && Keyboard.GetState().IsKeyUp(Keys.P) && Keyboard.GetState().IsKeyUp(Keys.K) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
	}
}

