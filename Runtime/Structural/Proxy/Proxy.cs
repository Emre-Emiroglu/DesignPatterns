namespace DesignPatterns.Runtime.Structural.Proxy
{
    public abstract class Proxy<T> : IProxy<T>
    {
        #region Fields
        // ReSharper disable once UnassignedReadonlyField
        protected readonly T Subject;
        #endregion

        #region Properties
        public T Value
        {
            get
            {
                EnsureSubject();
                
                return Subject;
            }
        }
        #endregion

        #region Core
        protected abstract void EnsureSubject();
        #endregion
    }
}