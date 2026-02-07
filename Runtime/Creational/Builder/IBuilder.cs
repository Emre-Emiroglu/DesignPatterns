namespace DesignPatterns.Runtime.Creational.Builder
{
    public interface IBuilder<out T>
    {
        public T Build();
        public void Reset();
    }
}