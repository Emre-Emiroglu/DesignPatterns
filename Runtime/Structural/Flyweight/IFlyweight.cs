namespace DesignPatterns.Runtime.Structural.Flyweight
{
    /// <summary>
    /// Represents a shared flyweight object.
    /// </summary>
    /// <typeparam name="TKey">The key to identifying the flyweight.</typeparam>
    public interface IFlyweight<out TKey>
    {
        /// <summary>
        /// Gets the unique key of the flyweight.
        /// </summary>
        public TKey Key { get; }
    }
}