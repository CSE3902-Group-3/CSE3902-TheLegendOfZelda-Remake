
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        //Prepare for later use
        private ItemScroll itemCycler;
        private EnemyCycler enemyCycler;
        private BlockCycler blockCycler;
        private IPlayer link;

        public ResetCommand(ItemScroll itemCycler, EnemyCycler enemyCycler, BlockCycler blockCycler, IPlayer link)
        {
            this.itemCycler = itemCycler;
            this.enemyCycler = enemyCycler;
            this.link = link;
            this.blockCycler = blockCycler; 
        }

        public void Execute()
        {
            link.Reset(); 
            enemyCycler.Reset();
            itemCycler.Reset();
            blockCycler.Reset();
        }

    }
}
