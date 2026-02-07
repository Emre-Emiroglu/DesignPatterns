namespace DesignPatterns.Runtime.Behavioral.Command
{
    public interface IUndoableCommand : ICommand
    {
        public void Undo();
    }
}