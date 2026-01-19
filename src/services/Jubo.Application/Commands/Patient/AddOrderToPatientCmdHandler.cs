using Jubo.Application.Models.Requests.Patient;
using Jubo.Application.Models.Results;
using Jubo.Domain.Aggregates.PatientAggregate;
using Jubo.Domain.Entities;
using MediatR;

namespace Jubo.Application.Commands.Patient
{
    public class AddOrderToPatientCmdHandler :
        IRequestHandler<AddOrderToPatientCmdRequest, ApiResult>
    {
        private readonly IPatientRepo _patientRepo;

        public AddOrderToPatientCmdHandler(
            IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<ApiResult> Handle(
            AddOrderToPatientCmdRequest request,
            CancellationToken cancellationToken)
        {
            var newOrder = new PatientOrder
            {
                PatientId = request.PatientId,
                Message = request.Message,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            await _patientRepo.AddPatientOrder(newOrder);
            await _patientRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResult();
        }
    }
}