namespace DomainModel.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
