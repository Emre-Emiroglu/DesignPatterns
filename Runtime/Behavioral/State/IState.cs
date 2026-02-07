namespace DesignPatterns.Runtime.Behavioral.State
{
    public interface IState<in TContext>
    {
        public void Enter(TContext context);
        public void Exit(TContext context);
        public void Update(TContext context);
    }
}