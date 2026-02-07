namespace DesignPatterns.Runtime.Behavioral.Memento
{
    public interface IOriginator<TMemento>
    {
        public TMemento CreateMemento();
        public void Restore(TMemento memento);
    }
}