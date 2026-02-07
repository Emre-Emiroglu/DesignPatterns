namespace DesignPatterns.Runtime.Creational.Builder
{
    /// <summary>
    /// Provides a base implementation for builders.
    /// </summary>
    /// <typeparam name="T">The type of object being built.</typeparam>
    public abstract class Builder<T> : IBuilder<T>
    {
        #region Core
        /// <summary>
        /// Builds and returns the final object.
        /// </summary>
        public abstract T Build();
        
        /// <summary>
        /// Resets the builder to its initial state.
        /// </summary>
        public abstract void Reset();
        #endregion
    }
}