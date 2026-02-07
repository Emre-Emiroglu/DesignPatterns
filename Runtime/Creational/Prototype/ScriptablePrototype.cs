using UnityEngine;

namespace DesignPatterns.Runtime.Creational.Prototype
{
    public abstract class ScriptablePrototype<T> : ScriptableObject, IPrototype<T> where T : ScriptableObject
    {
        #region Core
        public virtual T Clone() => Instantiate(this) as T;
        #endregion
    }
}