namespace DesignPatterns.Runtime.Creational.FactoryMethod
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}