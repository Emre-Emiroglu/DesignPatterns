namespace DesignPatterns.Runtime.Creational.Builder
{
    /// <summary>
    /// Defines a builder responsible for creating an object step by step.
    /// </summary>
    /// <typeparam name="T">The type of object being built.</typeparam>
    public interface IBuilder<out T>
    {
        /// <summary>
        /// Builds and returns the final object.
        /// </summary>
        /// <returns>The built object.</returns>
        public T Build();
        
        /// <summary>
        /// Resets the builder to its initial state.
        /// </summary>
        public void Reset();
    }
}