namespace DesignPatterns.Runtime.Behavioral.Visitor
{
    /// <summary>
    /// Represents an element that can be visited by a visitor.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    public interface IVisitable<out T>
    {
        /// <summary>
        /// Accepts a visitor.
        /// </summary>
        /// <param name="visitor">The visitor to accept.</param>
        public void Accept(IVisitor<T> visitor);
    }
}