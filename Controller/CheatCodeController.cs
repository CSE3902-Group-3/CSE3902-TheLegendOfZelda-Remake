using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class CheatCodeController : IController
	{
		private bool ReleasedKey;
		private RestoreHealthCommand restoreHealthCommand;
		private AddRupeeCommand addRupeeCommand;
		private KillEnemiesCommand killEnemiesCommand;
		private AddKeyCommand addKeyCommand;
		private AddBombCommand addBombCommand;

		public CheatCodeController()
		{
			ReleasedKey = false;
			restoreHealthCommand = new RestoreHealthCommand();
			addRupeeCommand = new AddRupeeCommand();
			killEnemiesCommand = new KillEnemiesCommand();
			addKeyCommand = new AddKeyCommand();
			addBombCommand = new AddBombCommand();
		}

		public void Update()
		{
            if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.H) && ReleasedKey)
            {
				restoreHealthCommand.Execute();
                ReleasedKey = false;
				SoundFactory.PlaySound(SoundFactory.getInstance().GetItem);
            }
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.P) && ReleasedKey)
			{
				addRupeeCommand.Execute();
				ReleasedKey = false;
				SoundFactory.PlaySound(SoundFactory.getInstance().GetRupee);
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.O) && ReleasedKey)
			{
				killEnemiesCommand.Execute();
				ReleasedKey = false;
				SoundFactory.PlaySound(SoundFactory.getInstance().EnemyDie);
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.K) && ReleasedKey)
			{
				addKeyCommand.Execute();
				ReleasedKey = false;
                SoundFactory.PlaySound(SoundFactory.getInstance().GetItem);
            }
			else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.T) && ReleasedKey)
			{
				addBombCommand.Execute();
				ReleasedKey = false;
				SoundFactory.PlaySound(SoundFactory.getInstance().GetItem);
			}

            if (Keyboard.GetState().IsKeyUp(Keys.C) && Keyboard.GetState().IsKeyUp(Keys.H) && Keyboard.GetState().IsKeyUp(Keys.P) && Keyboard.GetState().IsKeyUp(Keys.K) && Keyboard.GetState().IsKeyUp(Keys.T) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
	}
}

