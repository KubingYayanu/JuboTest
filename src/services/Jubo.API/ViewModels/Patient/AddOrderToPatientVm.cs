using System.Text.Json.Serialization;

namespace Jubo.API.ViewModels.Patient
{
    public class AddOrderToPatientRouteVm
    {
        [JsonPropertyName("patientId")]
        public int PatientId { get; set; }
    }

    public class AddOrderToPatientVm
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}