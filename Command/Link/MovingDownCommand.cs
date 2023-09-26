﻿using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;

namespace LegendOfZelda.Command.Link
{
    public class MovingDownCommand : ICommands
    {
        private IPlayer player;

        public MovingDownCommand(IPlayer link)
        {
            player = link;
        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new WalkDownLinkState(Game1.instance));
            player.stateMachine.Update();
        }
    }
}
