namespace DesignPatterns.Runtime.Behavioral.Observer
{
    /// <summary>
    /// Defines a subject that manages and notifies observers.
    /// </summary>
    /// <typeparam name="T">The type of the notification data.</typeparam>
    public interface ISubject<T>
    {
        /// <summary>
        /// Subscribes an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to subscribe.</param>
        public void Subscribe(IObserver<T> observer);
        
        /// <summary>
        /// Unsubscribes an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to unsubscribe.</param>
        public void Unsubscribe(IObserver<T> observer);
        
        /// <summary>
        /// Notifies all subscribed observers.
        /// </summary>
        /// <param name="data">The notification data.</param>
        public void Notify(T data);
    }
}