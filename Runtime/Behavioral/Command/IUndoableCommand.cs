namespace DesignPatterns.Runtime.Behavioral.Command
{
    /// <summary>
    /// Represents a command that supports undo operations.
    /// </summary>
    public interface IUndoableCommand : ICommand
    {
        /// <summary>
        /// Represents a command that supports undo operations.
        /// </summary>
        public void Undo();
    }
}