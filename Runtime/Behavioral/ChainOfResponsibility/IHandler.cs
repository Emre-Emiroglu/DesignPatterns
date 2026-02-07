namespace DesignPatterns.Runtime.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// Defines a handler capable of processing a request
    /// or delegating it to the next handler in the chain.
    /// </summary>
    /// <typeparam name="T">The type of the request.</typeparam>
    public interface IHandler<T>
    {
        /// <summary>
        /// Handles the given request.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <returns>
        /// True if the request was handled; otherwise, false.
        /// </returns>
        public bool Handle(T request);
        
        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="next">The next handler.</param>
        public void SetNext(IHandler<T> next);
    }
}