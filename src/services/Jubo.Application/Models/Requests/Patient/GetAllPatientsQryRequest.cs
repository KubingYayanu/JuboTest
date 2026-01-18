using Jubo.Application.Models.Results;
using MediatR;

namespace Jubo.Application.Models.Requests.Patient
{
    public class GetAllPatientsQryRequest : IRequest<ApiResult>
    {
    }
}