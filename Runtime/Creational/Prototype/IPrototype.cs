namespace DesignPatterns.Runtime.Creational.Prototype
{
    /// <summary>
    /// Defines an object capable of cloning itself.
    /// </summary>
    /// <typeparam name="T">The type of the cloned object.</typeparam>
    public interface IPrototype<out T>
    {
        /// <summary>
        /// Creates a clone of the object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public T Clone();
    }
}