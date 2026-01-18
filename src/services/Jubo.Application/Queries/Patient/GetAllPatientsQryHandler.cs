using Jubo.Application.Models.Requests.Patient;
using Jubo.Application.Models.Results;
using Jubo.Application.Models.Results.Patient;
using Jubo.Domain.Aggregates.PatientAggregate;
using MediatR;

namespace Jubo.Application.Queries.Patient
{
    public class GetAllPatientsQryHandler :
        IRequestHandler<GetAllPatientsQryRequest, ApiResult>
    {
        private readonly IPatientRepo _patientRepo;

        public GetAllPatientsQryHandler(
            IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<ApiResult> Handle(
            GetAllPatientsQryRequest request,
            CancellationToken cancellationToken)
        {
            var patients = await _patientRepo.GetAllPatients();

            var data = new GetAllPatientsQryResult
            {
                Patients = patients.Select(x => new GetAllPatientsQryResult.PatientItem
                    {
                        PatientId = x.Id,
                        Name = x.Name
                    })
                    .ToList()
            };

            return new ApiResult<GetAllPatientsQryResult>(data);
        }
    }
}