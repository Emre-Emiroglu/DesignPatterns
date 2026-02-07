using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Flyweight
{
    /// <summary>
    /// Manages and reuses flyweight instances.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TFlyweight">The flyweight type.</typeparam>
    public abstract class FlyweightFactory<TKey, TFlyweight> where TFlyweight : IFlyweight<TKey>
    {
        #region ReadonlyFields
        private readonly Dictionary<TKey, TFlyweight> _cache = new();
        #endregion

        #region Getters
        /// <summary>
        /// Gets an existing flyweight or creates a new one if not found.
        /// </summary>
        /// <param name="key">The flyweight key.</param>
        /// <returns>The flyweight instance.</returns>
        public TFlyweight Get(TKey key)
        {
            if (_cache.TryGetValue(key, out TFlyweight flyweight))
                return flyweight;

            flyweight = Create(key);
            
            _cache.Add(key, flyweight);

            return flyweight;
        }
        #endregion

        #region Core
        protected abstract TFlyweight Create(TKey key);
        #endregion
    }
}