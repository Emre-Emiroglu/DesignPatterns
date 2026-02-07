namespace DesignPatterns.Runtime.Behavioral.Strategy
{
    public interface IStrategy<in TInput, out TResult>
    {
        public TResult Execute(TInput input);
    }
}