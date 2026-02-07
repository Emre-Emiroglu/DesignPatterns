using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Composite
{
    /// <summary>
    /// Provides a base implementation for composite structures.
    /// </summary>
    /// <typeparam name="T">The type of the child elements.</typeparam>
    public abstract class Composite<T> : IComposite<T>
    {
        #region Fields
        private readonly List<T> _children = new();
        #endregion

        #region Getters
        /// <summary>
        /// Gets the child elements.
        /// </summary>
        public IEnumerable<T> Children => _children;
        #endregion

        #region Core
        /// <summary>
        /// Adds a child element.
        /// </summary>
        /// <param name="child">The child to add.</param>
        public virtual void Add(T child) => _children.Add(child);
        
        /// <summary>
        /// Removes a child element.
        /// </summary>
        /// <param name="child">The child to remove.</param>
        public virtual void Remove(T child) => _children.Remove(child);
        #endregion
    }
}