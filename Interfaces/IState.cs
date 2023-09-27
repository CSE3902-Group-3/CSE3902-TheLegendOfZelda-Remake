namespace LegendOfZelda
{
    public interface IState
    {
        public void Enter();
        public void Execute();
        public void Exit();
    }
}
