using UnityEngine;

namespace DesignPatterns.Runtime.Creational.Singleton
{
    /// <summary>
    /// Provides a MonoBehaviour-based singleton implementation.
    /// </summary>
    /// <typeparam name="T">The type of the MonoSingleton.</typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        #region Fields
        private static T _instance;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the singleton instance from the scene.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                _instance = FindFirstObjectByType<T>();

                if (!_instance)
                    Debug.LogError($"[MonoSingleton] Instance of {typeof(T).Name} not found in the scene.");

                return _instance;
            }
        }
        #endregion

        #region Core
        protected virtual void Awake()
        {
            if (_instance && !Equals(_instance, this))
            {
                Destroy(gameObject);
                
                return;
            }

            _instance = (T)this;
        }
        #endregion
    }
}