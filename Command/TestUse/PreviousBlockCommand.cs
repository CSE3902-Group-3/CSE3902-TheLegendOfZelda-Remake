
namespace LegendOfZelda
{
    public class PreviousBlockCommand : ICommands
    {
        BlockCycler blockCycler;

        public PreviousBlockCommand(BlockCycler blockCycler)
        {
            this.blockCycler = blockCycler;
        }

        public void Execute()
        {
            blockCycler.cycleBackward();
        }
    }
}
