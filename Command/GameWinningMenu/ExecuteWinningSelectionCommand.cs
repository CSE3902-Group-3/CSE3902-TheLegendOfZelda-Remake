namespace LegendOfZelda
{
    public class ExecuteWinningSelectionCommand : ICommands
    {
        private WinningSelector selector;

        public ExecuteWinningSelectionCommand()
        {
            selector = WinningState.selector;
        }

        public void Execute()
        {
            selector.ExecuteSelection();
        }
    }
}

