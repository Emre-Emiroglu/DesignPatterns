namespace DesignPatterns.Runtime.Creational.Builder
{
    public abstract class Builder<T> : IBuilder<T>
    {
        #region Core
        public abstract T Build();
        public abstract void Reset();
        #endregion
    }
}