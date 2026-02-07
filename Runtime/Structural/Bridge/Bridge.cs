namespace DesignPatterns.Runtime.Structural.Bridge
{
    /// <summary>
    /// Defines the abstraction side of the Bridge pattern.
    /// </summary>
    /// <typeparam name="T">The type of the implementation.</typeparam>
    public abstract class Bridge<T> where T : IBridgeImplementation
    {
        #region ReadonlyFields
        protected readonly T Implementation;
        #endregion

        #region Constructor
        protected Bridge(T implementation) => Implementation = implementation;
        #endregion
    }
}