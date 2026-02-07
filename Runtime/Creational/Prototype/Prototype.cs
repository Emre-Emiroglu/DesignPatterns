namespace DesignPatterns.Runtime.Creational.Prototype
{
    public abstract class Prototype<T> : IPrototype<T> where T : class
    {
        #region Core
        public virtual T Clone() => MemberwiseClone() as T;
        #endregion
    }
}