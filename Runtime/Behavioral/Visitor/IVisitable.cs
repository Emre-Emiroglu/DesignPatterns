namespace DesignPatterns.Runtime.Behavioral.Visitor
{
    public interface IVisitable<out T>
    {
        public void Accept(IVisitor<T> visitor);
    }
}