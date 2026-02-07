namespace DesignPatterns.Runtime.Creational.Builder
{
    /// <summary>
    /// Orchestrates the construction process using a builder.
    /// </summary>
    /// <typeparam name="T">The type of object being constructed.</typeparam>
    public sealed class Director<T>
    {
        #region ReadonlyFields
        private readonly IBuilder<T> _builder;
        #endregion

        #region Constrcutor
        /// <summary>
        /// Initializes the director with a builder.
        /// </summary>
        /// <param name="builder">The builder instance.</param>
        public Director(IBuilder<T> builder) => _builder = builder;
        #endregion

        #region Executes
        /// <summary>
        /// Constructs the object using the builder.
        /// </summary>
        /// <returns>The constructed object.</returns>
        public T Construct() => _builder.Build();
        
        /// <summary>
        /// Resets the builder state.
        /// </summary>
        public void Reset() => _builder.Reset();
        #endregion
    }
}