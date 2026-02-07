using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Observer
{
    /// <summary>
    /// Provides a base implementation for observable subjects.
    /// </summary>
    /// <typeparam name="T">The type of the notification data.</typeparam>
    public abstract class Subject<T> : ISubject<T>
    {
        #region ReadonlyFields
        private readonly List<IObserver<T>> _observers = new();
        #endregion

        #region Core
        /// <summary>
        /// Subscribes an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to subscribe.</param>
        public void Subscribe(IObserver<T> observer)
        {
            if (_observers.Contains(observer))
                return;
            
            _observers.Add(observer);
        }
        
        /// <summary>
        /// Unsubscribes an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to unsubscribe.</param>
        public void Unsubscribe(IObserver<T> observer) => _observers.Remove(observer);
        
        /// <summary>
        /// Notifies all subscribed observers.
        /// </summary>
        /// <param name="data">The notification data.</param>
        public void Notify(T data)
        {
            foreach (IObserver<T> observer in _observers)
                observer.OnNotified(data);
        }
        #endregion
    }
}