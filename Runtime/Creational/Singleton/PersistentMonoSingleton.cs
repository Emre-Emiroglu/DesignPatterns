namespace DesignPatterns.Runtime.Creational.Singleton
{
    /// <summary>
    /// Provides a persistent MonoBehaviour-based singleton
    /// that survives scene loads.
    /// </summary>
    /// <typeparam name="T">The type of the persistent MonoSingleton.</typeparam>
    public abstract class PersistentMonoSingleton<T> : MonoSingleton<T> where T : MonoSingleton<T>
    {
        #region Core
        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
}