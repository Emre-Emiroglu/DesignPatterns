using System;
using System.Collections.Generic;

namespace DesignPatterns.Runtime.Architectural
{
    /// <summary>
    /// Provides a global registry for resolving services by type.
    /// </summary>
    /// <remarks>
    /// Service Locator is a powerful but risky architectural pattern.
    /// Prefer Dependency Injection when possible.
    /// </remarks>
    public static class ServiceLocator
    {
        #region ReadonlyFields
        private static readonly Dictionary<Type, object> Services = new();
        #endregion

        #region Executes
        /// <summary>
        /// Registers a service instance for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="service">The service instance to register.</param>
        public static void Register<T>(T service) => Services[typeof(T)] = service;
        
        /// <summary>
        /// Clears all registered services.
        /// </summary>
        public static void Clear() => Services.Clear();
        
        /// <summary>
        /// Resolves a registered service by type.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <returns>The resolved service instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the requested service is not registered.
        /// </exception>
        public static T Resolve<T>()
        {
            if (Services.TryGetValue(typeof(T), out object service))
                return (T)service;

            throw new InvalidOperationException($"Service of type {typeof(T).Name} is not registered.");
        }
        #endregion
    }
}