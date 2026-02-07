namespace DesignPatterns.Runtime.Behavioral.Visitor
{
    /// <summary>
    /// Represents an operation to be performed on a visitable element.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    public interface IVisitor<in T>
    {
        /// <summary>
        /// Visits the specified element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        public void Visit(T element);
    }
}