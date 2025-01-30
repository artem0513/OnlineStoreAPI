using OnlineStore.Dtos;

namespace OnlineStore.Contracts.Services
{
    public interface IService<TId, TDto> where TDto : BaseDto<TId>
    {
        Task AddAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task AddAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default);

        Task DeleteAsync(TId id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(IEnumerable<TId> ids, bool saveChanges = true, CancellationToken cancellationToken = default);

        Task<TDto> GetAsync(TId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TDto>> GetAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);

        Task UpdateAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task UpdateAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
