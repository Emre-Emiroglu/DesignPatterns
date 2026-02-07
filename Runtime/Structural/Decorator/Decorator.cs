namespace DesignPatterns.Runtime.Structural.Decorator
{
    public abstract class Decorator<T> : IDecorator<T>
    {
        #region Fields
        protected readonly T Inner;
        #endregion

        #region Properties
        public T Value => Inner;
        #endregion

        #region Constructor
        protected Decorator(T inner) => Inner = inner;
        #endregion
    }
}