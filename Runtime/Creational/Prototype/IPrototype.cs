namespace DesignPatterns.Runtime.Creational.Prototype
{
    public interface IPrototype<out T>
    {
        public T Clone();
    }
}