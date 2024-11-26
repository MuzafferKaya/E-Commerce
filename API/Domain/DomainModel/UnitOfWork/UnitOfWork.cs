using DomainModel.Context;

namespace DomainModel.UnitOfWork
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task BeginTransactionAsync()
        {
            if (_appDbContext.Database.CurrentTransaction == null)
                await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_appDbContext.Database.CurrentTransaction != null)
                await _appDbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_appDbContext.Database.CurrentTransaction != null)
                await _appDbContext.Database.RollbackTransactionAsync();
        }

        public void SaveChanges() => _appDbContext.SaveChanges();

        public async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
    }
}
