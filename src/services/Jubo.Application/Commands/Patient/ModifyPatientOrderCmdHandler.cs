using System.Net;
using Jubo.Application.Models.Requests.Patient;
using Jubo.Application.Models.Results;
using Jubo.Domain.Aggregates.PatientAggregate;
using MediatR;

namespace Jubo.Application.Commands.Patient
{
    public class ModifyPatientOrderCmdHandler :
        IRequestHandler<ModifyPatientOrderCmdRequest, ApiResult>
    {
        private readonly IPatientRepo _patientRepo;

        public ModifyPatientOrderCmdHandler(
            IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<ApiResult> Handle(
            ModifyPatientOrderCmdRequest request,
            CancellationToken cancellationToken)
        {
            var order = await _patientRepo.GetPatientOrder(
                patientId: request.PatientId,
                orderId: request.OrderId);
            if (order == null)
            {
                var error = new ApiResult
                {
                    Code = (int)HttpStatusCode.BadRequest
                };
                return error;
            }

            order.Message = request.Message;

            _patientRepo.UpdatePatientOrder(order);
            await _patientRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResult();
        }
    }
}