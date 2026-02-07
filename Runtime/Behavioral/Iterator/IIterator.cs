namespace DesignPatterns.Runtime.Behavioral.Iterator
{
    /// <summary>
    /// Defines a sequential access interface for a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements being iterated.</typeparam>
    public interface IIterator<out T>
    {
        /// <summary>
        /// Determines whether there are more elements to iterate.
        /// </summary>
        /// <returns>True if another element exists; otherwise, false.</returns>
        public bool HasNext();
        
        /// <summary>
        /// Returns the next element in the iteration.
        /// </summary>
        /// <returns>The next element.</returns>
        public T Next();
        
        /// <summary>
        /// Resets the iterator to its initial position.
        /// </summary>
        public void Reset();
    }
}