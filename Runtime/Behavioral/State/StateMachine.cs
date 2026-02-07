namespace DesignPatterns.Runtime.Behavioral.State
{
    /// <summary>
    /// Manages state transitions and updates for a given context.
    /// </summary>
    /// <typeparam name="TContext">The type of the state context.</typeparam>
    public sealed class StateMachine<TContext>
    {
        #region Properities
        /// <summary>
        /// Gets the currently active state.
        /// </summary>
        public IState<TContext> CurrentState { get; private set; }
        #endregion

        #region State Control
        /// <summary>
        /// Changes the current state and triggers exit and enter callbacks.
        /// </summary>
        /// <param name="newState">The new state to activate.</param>
        /// <param name="context">The context associated with the state.</param>
        public void ChangeState(IState<TContext> newState, TContext context)
        {
            if (CurrentState == newState)
                return;

            CurrentState?.Exit(context);
            
            CurrentState = newState;
            
            CurrentState.Enter(context);
        }
        
        /// <summary>
        /// Updates the currently active state.
        /// </summary>
        /// <param name="context">The context associated with the state.</param>
        public void Update(TContext context) => CurrentState?.Update(context);
        #endregion
    }
}