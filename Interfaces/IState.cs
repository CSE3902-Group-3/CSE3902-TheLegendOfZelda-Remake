namespace LegendOfZelda.Interfaces
{
    public interface IState
    {
        public void Enter();
        public void Execute();
        public void Exit();
    }
}
