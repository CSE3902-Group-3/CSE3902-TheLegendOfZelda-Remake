namespace LegendOfZelda
{
    public class NextWinningSelectionCommand : ICommands
    {
        private WinningSelector selector;

        public NextWinningSelectionCommand()
        {
            selector = WinningState.selector;
        }

        public void Execute()
        {
            selector.nextOption();
        }
    }
}

