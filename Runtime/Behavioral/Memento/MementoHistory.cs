using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Memento
{
    /// <summary>
    /// Manages a history of mementos to support undo operations.
    /// </summary>
    /// <typeparam name="TMemento">The type of the memento.</typeparam>
    public sealed class MementoHistory<TMemento>
    {
        #region ReadonlyFields
        private readonly Stack<TMemento> _history = new();
        #endregion

        #region Executes
        /// <summary>
        /// Saves a memento to the history.
        /// </summary>
        /// <param name="memento">The memento to save.</param>
        public void Save(TMemento memento) => _history.Push(memento);
        
        /// <summary>
        /// Restores the last saved memento.
        /// </summary>
        /// <returns>The last saved memento, or default if none exist.</returns>
        public TMemento Undo() => _history.Count > 0 ? _history.Pop() : default;
        #endregion
    }
}