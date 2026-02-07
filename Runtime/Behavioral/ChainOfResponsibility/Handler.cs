namespace DesignPatterns.Runtime.Behavioral.ChainOfResponsibility
{
    public abstract class Handler<T> : IHandler<T>
    {
        #region Fields
        private IHandler<T> _next;
        #endregion

        #region Core
        public virtual bool Handle(T request)
        {
            if (CanHandle(request))
                return Process(request);

            return _next?.Handle(request) ?? false;
        }
        public void SetNext(IHandler<T> next) => _next = next;
        #endregion

        #region Executes
        protected abstract bool CanHandle(T request);
        protected abstract bool Process(T request);
        #endregion
    }
}