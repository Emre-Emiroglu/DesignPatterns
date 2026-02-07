using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Composite
{
    public interface IComposite<T>
    {
        public IEnumerable<T> Children { get; }
        public void Add(T child);
        public void Remove(T child);
    }
}