namespace DesignPatterns.Runtime.Behavioral.TemplateMethod
{
    /// <summary>
    /// Defines the skeleton of an algorithm, allowing subclasses
    /// to override specific steps.
    /// </summary>
    /// <typeparam name="TContext">The type of the execution context.</typeparam>
    public abstract class Template<TContext>
    {
        #region Executes
        /// <summary>
        /// Executes the algorithm following a fixed sequence.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public void Execute(TContext context)
        {
            OnStart(context);

            Process(context);
            
            OnFinish(context);
        }
        protected virtual void OnStart(TContext context) { }
        protected virtual void Process(TContext context) { }
        protected virtual void OnFinish(TContext context) { }
        #endregion
    }
}