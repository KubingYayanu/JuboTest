namespace Jubo.Domain.SeedWork
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public const string MedicalDatabaseSettings = "Medical:DatabaseSettings";
        
        public required string ConnectionString { get; set; }

        public required string DatabaseName { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}