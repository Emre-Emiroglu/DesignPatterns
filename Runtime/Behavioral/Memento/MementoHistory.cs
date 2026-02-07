using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Memento
{
    public sealed class MementoHistory<TMemento>
    {
        #region ReadonlyFields
        private readonly Stack<TMemento> _history = new();
        #endregion

        #region Executes
        public void Save(TMemento memento) => _history.Push(memento);
        public TMemento Undo() => _history.Count > 0 ? _history.Pop() : default;
        #endregion
    }
}