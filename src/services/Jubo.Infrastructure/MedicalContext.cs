using System.Data;
using System.Reflection;
using Jubo.Domain.Entities;
using Jubo.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Jubo.Infrastructure
{
    public class MedicalContext : DbContext, IUnitOfWork
    {
        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<PatientOrder> PatientOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            // EfMaps
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<ITransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Snapshot,
            CancellationToken cancellationToken = default)
        {
            var transaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return new DbTransaction(transaction);
        }
    }
}