namespace DesignPatterns.Runtime.Behavioral.Iterator
{
    public interface IIterable<out T>
    {
        public IIterator<T> CreateIterator();
    }
}