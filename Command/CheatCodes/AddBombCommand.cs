namespace LegendOfZelda
{
    public class AddBombCommand : ICommands
    {
        private AddBomb cheatCode;
        public AddBombCommand()
        {
            cheatCode = new AddBomb();
        }

        public void Execute()
        {
            cheatCode.Execute();
        }
    }
}

