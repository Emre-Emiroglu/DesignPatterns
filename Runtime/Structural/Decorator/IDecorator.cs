namespace DesignPatterns.Runtime.Structural.Decorator
{
    /// <summary>
    /// Represents a decorator that wraps a value.
    /// </summary>
    /// <typeparam name="T">The wrapped type.</typeparam>
    public interface IDecorator<out T>
    {
        /// <summary>
        /// Gets the wrapped value.
        /// </summary>
        public T Value { get; }
    }
}