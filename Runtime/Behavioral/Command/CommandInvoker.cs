using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Command
{
    /// <summary>
    /// Executes commands and manages undoable command history.
    /// </summary>
    public sealed class CommandInvoker
    {
        #region ReadonlyFields
        private readonly Stack<IUndoableCommand> _history = new();
        #endregion

        #region Execute
        /// <summary>
        /// Executes the given command and stores it if it supports undo.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void Execute(ICommand command)
        {
            command.Execute();

            if (command is IUndoableCommand undoableCommand)
                _history.Push(undoableCommand);
        }
        
        /// <summary>
        /// Undoes the last executed undoable command.
        /// </summary>
        public void Undo()
        {
            if (_history.Count == 0)
                return;

            IUndoableCommand command = _history.Pop();
            
            command.Undo();
        }
        #endregion
    }
}