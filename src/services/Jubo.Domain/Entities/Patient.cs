namespace Jubo.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// [Navigation Property]
        /// </summary>
        public List<PatientOrder> Orders { get; set; }
    }
}