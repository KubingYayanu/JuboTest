using Microsoft.EntityFrameworkCore.Storage;

namespace Jubo.Domain.SeedWork
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _efTransaction;

        public DbTransaction(IDbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return _efTransaction.CommitAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return _efTransaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            _efTransaction.Dispose();
        }
    }
}