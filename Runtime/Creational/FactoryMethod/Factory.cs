namespace DesignPatterns.Runtime.Creational.FactoryMethod
{
    public abstract class Factory<T> : IFactory<T>
    {
        #region Core
        public T Create() => CreateInternal();
        #endregion

        #region Executes
        protected abstract T CreateInternal();
        #endregion
    }
}