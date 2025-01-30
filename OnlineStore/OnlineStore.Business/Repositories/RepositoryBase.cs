using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Contracts.Repositories;
using OnlineStore.Dtos;
using OnlineStore.Entities;

namespace OnlineStore.Business.Repositories
{
    internal class RepositoryBase<TId, TDto, TEntity, TDbContext> : IRepository<TId, TDto>
        where TDto : BaseDto<TId>
        where TEntity : class, IEntity<TId>
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;
        private readonly IMapper mapper;

        public RepositoryBase(TDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entity = mapper.Map<TEntity>(dto);
            await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            if (saveChanges)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entities = dtos.Select(mapper.Map<TEntity>);
            await dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            if (saveChanges)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TId id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                if (saveChanges)
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public async Task DeleteAsync(IEnumerable<TId> ids, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entities = await dbContext.Set<TEntity>().Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
            if (entities.Count != 0)
            {
                dbContext.Set<TEntity>().RemoveRange(entities);
                if (saveChanges)
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public async Task<TDto?> GetAsync(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
            return entity != null ? mapper.Map<TDto>(entity) : null;
        }

        public async Task<IEnumerable<TDto>> GetAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
        {
            var entities = await dbContext.Set<TEntity>().Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
            return entities.Select(mapper.Map<TDto>);
        }

        public async Task UpdateAsync(TDto dto, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync([dto.Id], cancellationToken);
            if (entity != null)
            {
                mapper.Map(dto, entity);
                dbContext.Set<TEntity>().Update(entity);
                if (saveChanges)
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public async Task UpdateAsync(IEnumerable<TDto> dtos, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var entities = await dbContext.Set<TEntity>().Where(e => dtos.Select(d => d.Id).Contains(e.Id)).ToListAsync(cancellationToken);
            foreach (var entity in entities)
            {
                var dto = dtos.First(d => Equals(d.Id, entity.Id));
                mapper.Map(dto, entity);
            }
            dbContext.Set<TEntity>().UpdateRange(entities);
            if (saveChanges)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
            return entities.Select(mapper.Map<TDto>);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
