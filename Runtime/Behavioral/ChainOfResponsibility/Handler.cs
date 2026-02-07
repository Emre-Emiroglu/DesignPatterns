namespace DesignPatterns.Runtime.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// Provides a base implementation for the chain of responsibility handlers.
    /// </summary>
    /// <typeparam name="T">The type of the request.</typeparam>
    public abstract class Handler<T> : IHandler<T>
    {
        #region Fields
        private IHandler<T> _next;
        #endregion

        #region Core
        /// <summary>
        /// Attempts to handle the request or forwards it to the next handler.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <returns>
        /// True if the request was handled; otherwise, false.
        /// </returns>
        public virtual bool Handle(T request)
        {
            if (CanHandle(request))
                return Process(request);

            return _next?.Handle(request) ?? false;
        }
        
        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="next">The next handler.</param>
        public void SetNext(IHandler<T> next) => _next = next;
        #endregion

        #region Executes
        protected abstract bool CanHandle(T request);
        protected abstract bool Process(T request);
        #endregion
    }
}