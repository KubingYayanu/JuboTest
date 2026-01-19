using Jubo.Application.Models.Results;
using MediatR;

namespace Jubo.Application.Models.Requests.Patient
{
    public class AddOrderToPatientCmdRequest : IRequest<ApiResult>
    {
        public AddOrderToPatientCmdRequest(
            int patientId,
            string message)
        {
            PatientId = patientId;
            Message = message;
        }

        public int PatientId { get; set; }

        public string Message { get; set; }
    }
}