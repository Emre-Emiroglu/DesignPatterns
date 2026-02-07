namespace DesignPatterns.Runtime.Behavioral.Memento
{
    /// <summary>
    /// Defines an object capable of creating and restoring mementos.
    /// </summary>
    /// <typeparam name="TMemento">The type of the memento.</typeparam>
    public interface IOriginator<TMemento>
    {
        /// <summary>
        /// Creates a memento representing the current state.
        /// </summary>
        /// <returns>The created memento.</returns>
        public TMemento CreateMemento();
        
        /// <summary>
        /// Restores the object's state from a memento.
        /// </summary>
        /// <param name="memento">The memento to restore from.</param>
        public void Restore(TMemento memento);
    }
}