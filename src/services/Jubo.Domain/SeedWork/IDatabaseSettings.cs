namespace Jubo.Domain.SeedWork
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string UserName { get; set; }

        string Password { get; set; }
    }
}