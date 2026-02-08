namespace DesignPatterns.Runtime.Structural.Proxy
{
    /// <summary>
    /// Provides a base implementation for proxy objects.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    public abstract class Proxy<T> : IProxy<T>
    {
        #region Fields
        protected T Subject;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the proxied value, ensuring the subject is initialized.
        /// </summary>
        public T Value
        {
            get
            {
                EnsureSubject();
                
                return Subject;
            }
        }
        #endregion

        #region Core
        protected abstract void EnsureSubject();
        #endregion
    }
}