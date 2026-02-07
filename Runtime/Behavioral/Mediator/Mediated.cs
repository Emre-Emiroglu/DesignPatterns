namespace DesignPatterns.Runtime.Behavioral.Mediator
{
    /// <summary>
    /// Provides a base implementation for mediated components.
    /// </summary>
    public abstract class Mediated : IMediated
    {
        #region Fields
        protected IMediator Mediator;
        #endregion

        #region Core
        /// <summary>
        /// Assigns a mediator to the component.
        /// </summary>
        /// <param name="mediator">The mediator instance.</param>
        public void SetMediator(IMediator mediator) => Mediator = mediator;
        #endregion
    }
}