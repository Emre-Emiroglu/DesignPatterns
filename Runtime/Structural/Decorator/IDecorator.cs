namespace DesignPatterns.Runtime.Structural.Decorator
{
    public interface IDecorator<out T>
    {
        public T Value { get; }
    }
}