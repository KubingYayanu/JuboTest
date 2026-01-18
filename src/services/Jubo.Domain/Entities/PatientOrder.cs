namespace Jubo.Domain.Entities
{
    public class PatientOrder
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// [Navigation Property]
        /// </summary>
        public Patient Patient { get; set; }
    }
}