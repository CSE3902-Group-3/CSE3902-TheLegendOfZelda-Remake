namespace LegendOfZelda
{
    public class AddKeyCommand : ICommands
    {
        private AddKey cheatCode;
        public AddKeyCommand()
        {
            cheatCode = new AddKey();
        }

        public void Execute()
        {
            cheatCode.Execute();
        }
    }
}

