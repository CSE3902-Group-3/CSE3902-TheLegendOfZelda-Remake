
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        //Prepare for later use
        private ItemScroll itemCycler;
        private EnemyCycler enemyCycler;
        private IPlayer link;

        public ResetCommand(ItemScroll itemCycler, EnemyCycler enemyCycler, IPlayer link)
        {
            this.itemCycler = itemCycler;
            this.enemyCycler = enemyCycler;
            this.link = link;
        }

        public void Execute()
        {
           link.Reset(); 
           enemyCycler.Reset();
           itemCycler.Reset();
        }

    }
}
