namespace DesignPatterns.Runtime.Structural.Flyweight
{
    public interface IFlyweight<out TKey>
    {
        public TKey Key { get; }
    }
}