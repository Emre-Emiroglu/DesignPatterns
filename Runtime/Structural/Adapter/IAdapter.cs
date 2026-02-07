namespace DesignPatterns.Runtime.Structural.Adapter
{
    /// <summary>
    /// Represents an adapter that converts an interface into another.
    /// </summary>
    /// <typeparam name="T">The adapted type.</typeparam>
    public interface IAdapter<out T>
    {
        /// <summary>
        /// Adapts and returns the target representation.
        /// </summary>
        /// <returns>The adapted value.</returns>
        public T Adapt();
    }
}