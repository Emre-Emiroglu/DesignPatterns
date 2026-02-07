namespace DesignPatterns.Runtime.Behavioral.Iterator
{
    public interface IIterator<out T>
    {
        public bool HasNext();
        public T Next();
        public void Reset();
    }
}