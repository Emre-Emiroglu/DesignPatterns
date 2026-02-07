using UnityEngine;

namespace DesignPatterns.Runtime.Creational.Prototype
{
    /// <summary>
    /// Provides a Unity-specific prototype implementation
    /// using ScriptableObject instantiation.
    /// </summary>
    /// <typeparam name="T">The type of the ScriptableObject prototype.</typeparam>
    public abstract class ScriptablePrototype<T> : ScriptableObject, IPrototype<T> where T : ScriptableObject
    {
        #region Core
        /// <summary>
        /// Creates a clone of the ScriptableObject.
        /// </summary>
        /// <returns>The cloned ScriptableObject instance.</returns>
        public virtual T Clone() => Instantiate(this) as T;
        #endregion
    }
}