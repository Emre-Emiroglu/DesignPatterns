namespace DesignPatterns.Runtime.Structural.Adapter
{
    public interface IAdapter<out T>
    {
        public T Adapt();
    }
}