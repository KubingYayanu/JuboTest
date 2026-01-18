using System.Data;

namespace Jubo.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<ITransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Snapshot,
            CancellationToken cancellationToken = default);
    }
}