namespace DesignPatterns.Runtime.Structural.Proxy
{
    /// <summary>
    /// Represents a proxy that controls access to a subject.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    public interface IProxy<out T>
    {
        /// <summary>
        /// Gets the proxied value.
        /// </summary>
        public T Value { get; }
    }
}