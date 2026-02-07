namespace DesignPatterns.Runtime.Structural.Proxy
{
    public interface IProxy<out T>
    {
        public T Value { get; }
    }
}