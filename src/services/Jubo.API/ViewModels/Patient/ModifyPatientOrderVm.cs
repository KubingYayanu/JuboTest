using System.Text.Json.Serialization;

namespace Jubo.API.ViewModels.Patient
{
    public class ModifyPatientOrderRouteVm
    {
        [JsonPropertyName("patientId")]
        public int PatientId { get; set; }

        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }
    }

    public class ModifyPatientOrderVm
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}