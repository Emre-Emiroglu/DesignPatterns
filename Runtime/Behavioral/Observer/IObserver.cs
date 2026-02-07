namespace DesignPatterns.Runtime.Behavioral.Observer
{
    public interface IObserver<in T>
    {
        public void OnNotified(T data);
    }
}