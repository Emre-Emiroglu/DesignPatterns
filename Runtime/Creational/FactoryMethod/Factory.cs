namespace DesignPatterns.Runtime.Creational.FactoryMethod
{
    /// <summary>
    /// Provides a base implementation for the factory method pattern.
    /// </summary>
    /// <typeparam name="T">The type of object being created.</typeparam>
    public abstract class Factory<T> : IFactory<T>
    {
        #region Core
        /// <summary>
        /// Creates a new object instance.
        /// </summary>
        /// <returns>The created object.</returns>
        public T Create() => CreateInternal();
        #endregion

        #region Executes
        protected abstract T CreateInternal();
        #endregion
    }
}