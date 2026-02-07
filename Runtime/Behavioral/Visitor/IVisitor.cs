namespace DesignPatterns.Runtime.Behavioral.Visitor
{
    public interface IVisitor<in T>
    {
        public void Visit(T element);
    }
}