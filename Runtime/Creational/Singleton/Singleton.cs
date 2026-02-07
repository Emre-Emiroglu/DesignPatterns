namespace DesignPatterns.Runtime.Creational.Singleton
{
    /// <summary>
    /// Provides a thread-safe generic singleton implementation.
    /// </summary>
    /// <typeparam name="T">The type of the singleton instance.</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        #region ReadonlyFields
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new();
        #endregion

        #region Fields
        private static T _instance;
        #endregion
        
        #region Properties
        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (Lock)
                    _instance ??= new T();

                return _instance;
            }
        }
        #endregion
    }
}