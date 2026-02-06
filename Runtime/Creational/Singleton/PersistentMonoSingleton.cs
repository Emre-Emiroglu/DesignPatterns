namespace DesignPatterns.Runtime.Creational.Singleton
{
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