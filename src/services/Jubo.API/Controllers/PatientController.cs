using Jubo.API.ViewModels.Patient;
using Jubo.Application.Models.Requests.Patient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jubo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPatientsQryRequest();

            var response = await _mediator.Send(query);

            return StatusCode(response.Code, response);
        }

        [HttpPost("{patientId}/order/add")]
        public async Task<IActionResult> AddOrderToPatient(
            [FromRoute] AddOrderToPatientRouteVm route,
            [FromBody] AddOrderToPatientVm request)
        {
            var command = new AddOrderToPatientCmdRequest(
                patientId: route.PatientId,
                message: request.Message);

            var response = await _mediator.Send(command);

            return StatusCode(response.Code, response);
        }

        [HttpPatch("{patientId}/order/{orderId}/modify")]
        public async Task<IActionResult> ModifyPatientOrder(
            [FromRoute] ModifyPatientOrderRouteVm route,
            [FromBody] ModifyPatientOrderVm request)
        {
            var command = new ModifyPatientOrderCmdRequest(
                patientId: route.PatientId,
                orderId: route.OrderId,
                message: request.Message);

            var response = await _mediator.Send(command);

            return StatusCode(response.Code, response);
        }
    }
}