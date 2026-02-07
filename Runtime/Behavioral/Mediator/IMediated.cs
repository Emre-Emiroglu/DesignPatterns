namespace DesignPatterns.Runtime.Behavioral.Mediator
{
    /// <summary>
    /// Represents a component that communicates through a mediator.
    /// </summary>
    public interface IMediated
    {
        /// <summary>
        /// Assigns a mediator to the component.
        /// </summary>
        /// <param name="mediator">The mediator instance.</param>
        public void SetMediator(IMediator mediator);
    }
}