namespace GJ.CQRSCore.Interfaces
{
    public interface IQueryHandler<T, X> where T : IQuery
    {
        X Execute(T query);
    }
}
