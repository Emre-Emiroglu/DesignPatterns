namespace DesignPatterns.Runtime.Creational.Prototype
{
    /// <summary>
    /// Provides a base implementation for the prototype pattern
    /// using shallow copy semantics.
    /// </summary>
    /// <typeparam name="T">The type of the prototype.</typeparam>
    public abstract class Prototype<T> : IPrototype<T> where T : class
    {
        #region Core
        /// <summary>
        /// Creates a shallow copy of the object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public virtual T Clone() => MemberwiseClone() as T;
        #endregion
    }
}