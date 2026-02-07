using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Composite
{
    public abstract class Composite<T> : IComposite<T>
    {
        #region Fields
        private readonly List<T> _children = new();
        #endregion

        #region Getters
        public IEnumerable<T> Children => _children;
        #endregion

        #region Core
        public virtual void Add(T child) => _children.Add(child);
        public virtual void Remove(T child) => _children.Remove(child);
        #endregion
    }
}