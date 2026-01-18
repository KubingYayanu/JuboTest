namespace Jubo.Domain.SeedWork
{
    public interface IRepo
    {
        IUnitOfWork UnitOfWork { get; }
    }
}