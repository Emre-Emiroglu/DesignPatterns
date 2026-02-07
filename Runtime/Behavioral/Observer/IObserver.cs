namespace DesignPatterns.Runtime.Behavioral.Observer
{
    /// <summary>
    /// Represents an observer that reacts to notifications.
    /// </summary>
    /// <typeparam name="T">The type of the notification data.</typeparam>
    public interface IObserver<in T>
    {
        /// <summary>
        /// Called when the subject notifies observers.
        /// </summary>
        /// <param name="data">The notification data.</param>
        public void OnNotified(T data);
    }
}