using System.Collections.Generic;

namespace DesignPatterns.Runtime.Behavioral.Command
{
    public sealed class CommandInvoker
    {
        #region ReadonlyFields
        private readonly Stack<IUndoableCommand> _history = new();
        #endregion

        #region Execute
        public void Execute(ICommand command)
        {
            command.Execute();

            if (command is IUndoableCommand undoableCommand)
                _history.Push(undoableCommand);
        }
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