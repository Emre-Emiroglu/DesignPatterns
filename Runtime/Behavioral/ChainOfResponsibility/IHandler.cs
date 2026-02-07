namespace DesignPatterns.Runtime.Behavioral.ChainOfResponsibility
{
    public interface IHandler<T>
    {
        public bool Handle(T request);
        public void SetNext(IHandler<T> next);
    }
}