namespace Jubo.Application.Models.Results.Patient
{
    public class GetAllPatientsQryResult
    {
        public List<PatientItem> Patients { get; set; }

        public class PatientItem
        {
            public int PatientId { get; set; }

            public string Name { get; set; }

            public List<OrderItem> Orders { get; set; }
        }
        
        public class OrderItem
        {
            public int OrderId { get; set; }

            public string Message { get; set; }
        }
    }
}