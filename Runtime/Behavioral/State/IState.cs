namespace DesignPatterns.Runtime.Behavioral.State
{
    /// <summary>
    /// Represents a state with entry, update, and exit behaviors.
    /// </summary>
    /// <typeparam name="TContext">The type of the state context.</typeparam>
    public interface IState<in TContext>
    {
        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        /// <param name="context">The state context.</param>
        public void Enter(TContext context);
        
        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        /// <param name="context">The state context.</param>
        public void Exit(TContext context);
        
        /// <summary>
        /// Updates the state behavior.
        /// </summary>
        /// <param name="context">The state context.</param>
        public void Update(TContext context);
    }
}