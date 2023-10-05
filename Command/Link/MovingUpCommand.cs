﻿
namespace LegendOfZelda
{
    public class MovingUpCommand : ICommands
    {

        private IPlayer player;

        public MovingUpCommand(IPlayer link)
        {
            player = link;
            
        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new WalkUpLinkState());
            player.stateMachine.Update();
        }
    }
}
