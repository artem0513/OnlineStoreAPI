using OnlineStore.Contracts.Repositories;
using OnlineStore.Contracts.Services;
using OnlineStore.Dtos;

namespace OnlineStore.Business.Services
{
    internal class ServiceBase<TId, TDto, TRepository> : IService<TId, TDto>
        where TDto : BaseDto<TId>
        where TRepository : IRepository<TId, TDto>
    {
        private readonly TRepository repository;

        public ServiceBase(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.AddAsync(dto, saveChanges, cancellationToken);
        }

        public async Task AddAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.AddAsync(dtos, saveChanges, cancellationToken);
        }

        public async Task DeleteAsync(TId id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.DeleteAsync(id, saveChanges, cancellationToken);
        }

        public async Task DeleteAsync(IEnumerable<TId> ids, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.DeleteAsync(ids, saveChanges, cancellationToken);
        }

        public async Task<TDto> GetAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await repository.GetAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TDto>> GetAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
        {
            return await repository.GetAsync(ids, cancellationToken);
        }

        public async Task UpdateAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.UpdateAsync(dto, saveChanges, cancellationToken);
        }

        public async Task UpdateAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await repository.UpdateAsync(dtos, saveChanges, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await repository.SaveChangesAsync(cancellationToken);
        }
    }
}
