namespace CQRSCore.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Execute(T command);
    }
}
