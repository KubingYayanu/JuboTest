using Jubo.Domain.Aggregates.PatientAggregate;
using Jubo.Domain.Entities;
using Jubo.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Jubo.Infrastructure.Repos
{
    public class PatientRepo : IPatientRepo
    {
        private readonly MedicalContext _context;

        public PatientRepo(MedicalContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patient
                .Include(x => x.Orders)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddPatientOrder(PatientOrder order)
        {
            await _context.PatientOrder.AddAsync(order);
        }
    }
}