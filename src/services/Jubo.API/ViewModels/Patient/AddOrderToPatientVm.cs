using System.Text.Json.Serialization;

namespace Jubo.API.ViewModels.Patient
{
    public class AddOrderToPatientVm
    {
        [JsonPropertyName("patientId")]
        public int PatientId { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}