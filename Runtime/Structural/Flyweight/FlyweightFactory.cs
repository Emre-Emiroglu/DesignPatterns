using System.Collections.Generic;

namespace DesignPatterns.Runtime.Structural.Flyweight
{
    public abstract class FlyweightFactory<TKey, TFlyweight> where TFlyweight : IFlyweight<TKey>
    {
        #region ReadonlyFields
        private readonly Dictionary<TKey, TFlyweight> _cache = new();
        #endregion

        #region Getters
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