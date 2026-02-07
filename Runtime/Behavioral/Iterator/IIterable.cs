namespace DesignPatterns.Runtime.Behavioral.Iterator
{
    /// <summary>
    /// Defines a collection that can create an iterator.
    /// </summary>
    /// <typeparam name="T">The type of elements being iterated.</typeparam>
    public interface IIterable<out T>
    {
        /// <summary>
        /// Creates an iterator for the collection.
        /// </summary>
        /// <returns>An iterator instance.</returns>
        public IIterator<T> CreateIterator();
    }
}