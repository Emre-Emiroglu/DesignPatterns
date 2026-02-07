using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Composite
{
    /// <summary>
    /// Defines a composite structure that can contain child elements.
    /// </summary>
    /// <typeparam name="T">The type of the child elements.</typeparam>
    public interface IComposite<T>
    {
        /// <summary>
        /// Gets the child elements.
        /// </summary>
        public IEnumerable<T> Children { get; }
        
        /// <summary>
        /// Adds a child element.
        /// </summary>
        /// <param name="child">The child to add.</param>
        public void Add(T child);
        
        /// <summary>
        /// Removes a child element.
        /// </summary>
        /// <param name="child">The child to remove.</param>
        public void Remove(T child);
    }
}