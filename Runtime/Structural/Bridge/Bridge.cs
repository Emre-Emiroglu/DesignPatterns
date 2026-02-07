namespace DesignPatterns.Runtime.Structural.Bridge
{
    public abstract class Bridge<T>
    {
        #region ReadonlyFields
        protected readonly T Implementation;
        #endregion

        #region Constructor
        protected Bridge(T implementation) => Implementation = implementation;
        #endregion
    }
}