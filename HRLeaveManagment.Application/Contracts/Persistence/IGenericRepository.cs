using HRLeaveManagment.Domain.Common;

namespace HRLeaveManagment.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
    }
}
