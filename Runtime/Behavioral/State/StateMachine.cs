namespace DesignPatterns.Runtime.Behavioral.State
{
    public sealed class StateMachine<TContext>
    {
        #region Getters
        public IState<TContext> CurrentState { get; private set; }
        #endregion

        #region State Control
        public void ChangeState(IState<TContext> newState, TContext context)
        {
            if (CurrentState == newState)
                return;

            CurrentState?.Exit(context);
            
            CurrentState = newState;
            
            CurrentState.Enter(context);
        }
        public void Update(TContext context) => CurrentState?.Update(context);
        #endregion
    }
}