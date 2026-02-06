namespace DesignPatterns.Runtime.Creational.Singleton
{
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