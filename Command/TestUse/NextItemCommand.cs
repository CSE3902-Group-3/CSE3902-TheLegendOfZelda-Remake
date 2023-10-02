
namespace LegendOfZelda
{
    public class NextItemCommand : ICommands
    {
        ItemScroll itemCycler;

        public NextItemCommand(ItemScroll itemCycler)
        {
            this.itemCycler = itemCycler;
        }

        public void Execute()
        {
            itemCycler.nextItem();
        }
    }
}
