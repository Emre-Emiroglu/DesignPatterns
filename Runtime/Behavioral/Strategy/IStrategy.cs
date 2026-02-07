namespace DesignPatterns.Runtime.Behavioral.Strategy
{
    /// <summary>
    /// Represents a strategy that executes an algorithm.
    /// </summary>
    /// <typeparam name="TInput">The input type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IStrategy<in TInput, out TResult>
    {
        /// <summary>
        /// Executes the strategy logic.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>The result of the execution.</returns>
        public TResult Execute(TInput input);
    }
}