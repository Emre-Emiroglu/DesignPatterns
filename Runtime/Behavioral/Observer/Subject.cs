using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Observer
{
    public abstract class Subject<T> : ISubject<T>
    {
        #region ReadonlyFields
        private readonly List<IObserver<T>> _observers = new();
        #endregion

        #region Core
        public void Subscribe(IObserver<T> observer)
        {
            if (_observers.Contains(observer))
                return;
            
            _observers.Add(observer);
        }
        public void Unsubscribe(IObserver<T> observer) => _observers.Remove(observer);
        public void Notify(T data)
        {
            foreach (IObserver<T> observer in _observers)
                observer.OnNotified(data);
        }
        #endregion
    }
}