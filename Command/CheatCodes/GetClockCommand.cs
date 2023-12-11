namespace LegendOfZelda
{
    public class GetClockCommand : ICommands
    {
        private GetClock cheatCode;
        public GetClockCommand()
        {
            cheatCode = new GetClock();
        }

        public void Execute()
        {
            cheatCode.Execute();
        }
    }
}

