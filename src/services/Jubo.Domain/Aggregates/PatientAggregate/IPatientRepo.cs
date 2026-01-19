using Jubo.Domain.Entities;
using Jubo.Domain.SeedWork;

namespace Jubo.Domain.Aggregates.PatientAggregate
{
    public interface IPatientRepo : IRepo
    {
        Task<List<Patient>> GetAllPatients();
        
        Task AddPatientOrder(PatientOrder order);
    }
}