
namespace LegendOfZelda
{
    public class NextBlockCommand : ICommands
    {
        BlockCycler blockCycler;

        public NextBlockCommand(BlockCycler blockCycler) {
            this.blockCycler = blockCycler;
        }

        public void Execute()
        {
            blockCycler.cycleForward();
        }
    }
}
