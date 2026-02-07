namespace DesignPatterns.Runtime.Structural.Decorator
{
    /// <summary>
    /// Provides a base implementation for decorators.
    /// </summary>
    /// <typeparam name="T">The wrapped type.</typeparam>
    public abstract class Decorator<T> : IDecorator<T>
    {
        #region Fields
        protected readonly T Inner;
        #endregion

        #region Getters
        /// <summary>
        /// Gets the wrapped value.
        /// </summary>
        public T Value => Inner;
        #endregion

        #region Constructor
        protected Decorator(T inner) => Inner = inner;
        #endregion
    }
}