namespace DesignPatterns.Runtime.Behavioral.Mediator
{
    public abstract class Mediated : IMediated
    {
        #region Fields
        protected IMediator Mediator;
        #endregion

        #region Core
        public void SetMediator(IMediator mediator) => Mediator = mediator;
        #endregion
    }
}