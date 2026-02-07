namespace DesignPatterns.Runtime.Creational.FactoryMethod
{
    /// <summary>
    /// Defines a factory responsible for creating objects.
    /// </summary>
    /// <typeparam name="T">The type of object created by the factory.</typeparam>
    public interface IFactory<out T>
    {
        /// <summary>
        /// Creates a new object instance.
        /// </summary>
        /// <returns>The created object.</returns>
        public T Create();
    }
}