
namespace iTransition.Forms.Domain
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        void Save();
        Task SaveAsync();
    }
}