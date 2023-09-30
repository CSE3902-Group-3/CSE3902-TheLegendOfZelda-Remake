
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        //Prepare for later use
        private ItemScroll itemCycler;

        public ResetCommand(ItemScroll itemCycler)
        {
            this.itemCycler = itemCycler;
        }

        public void Execute()
        {
           itemCycler.Reset();
        }

    }
}
