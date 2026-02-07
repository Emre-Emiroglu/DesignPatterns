namespace DesignPatterns.Runtime.Behavioral.Mediator
{
    public interface IMediator
    {
        public void Notify(object sender, string eventId);
    }
}