using Jubo.Application.Models.Results;
using MediatR;

namespace Jubo.Application.Models.Requests.Patient
{
    public class ModifyPatientOrderCmdRequest : IRequest<ApiResult>
    {
        public ModifyPatientOrderCmdRequest(
            int patientId,
            int orderId,
            string message)
        {
            PatientId = patientId;
            OrderId = orderId;
            Message = message;
        }

        public int PatientId { get; set; }

        public int OrderId { get; set; }

        public string Message { get; set; }
    }
}