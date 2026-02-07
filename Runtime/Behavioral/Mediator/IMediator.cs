namespace DesignPatterns.Runtime.Behavioral.Mediator
{
    /// <summary>
    /// Defines a mediator that coordinates communication between components.
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Notifies the mediator about an event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="eventId">The identifier of the event.</param>
        public void Notify(object sender, string eventId);
    }
}