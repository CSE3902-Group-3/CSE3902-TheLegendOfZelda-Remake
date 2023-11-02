namespace LegendOfZelda
{
    public class UnpauseCommand : ICommands
    {
        private PauseManager pauseHandler;

        public UnpauseCommand(PauseManager pauseManager)
        {
            pauseHandler = pauseManager;
        }

        public void Execute()
        {
            pauseHandler.Resume();
        }
    }
}
