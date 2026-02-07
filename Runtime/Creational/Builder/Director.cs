namespace DesignPatterns.Runtime.Creational.Builder
{
    public sealed class Director<T>
    {
        #region ReadonlyFields
        private readonly IBuilder<T> _builder;
        #endregion

        #region Constrcutor
        public Director(IBuilder<T> builder) => _builder = builder;
        #endregion

        #region Executes
        public T Construct() => _builder.Build();
        public void Reset() => _builder.Reset();
        #endregion
    }
}