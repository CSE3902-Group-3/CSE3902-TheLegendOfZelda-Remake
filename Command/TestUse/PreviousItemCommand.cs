
namespace LegendOfZelda
{
    public class PreviousItemCommand : ICommands
    {
        ItemScroll itemCycler;
        public PreviousItemCommand(ItemScroll itemCycler)
        {
            this.itemCycler = itemCycler;
        }
        public void Execute()
        {
            itemCycler.previousItem();
        }
    }
}
