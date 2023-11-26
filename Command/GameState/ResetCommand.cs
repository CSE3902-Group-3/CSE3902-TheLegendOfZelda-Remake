
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        //Prepare for later use
        private Link link;

        public ResetCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.Die();
        }

    }
}
