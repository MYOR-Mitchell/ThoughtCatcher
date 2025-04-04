using ThoughtCatcher.Core.Models;

namespace ThoughtCatcher.Core.Interfaces
{
    public interface IThoughtRepository
    {
        Task<IEnumerable<Thought>> GetAllAsync(); 
        Task<Thought?> GetByIdAsync(int id);
        Task AddAsync(Thought thought);
        Task UpdateAsync(Thought thought);
        Task DeleteAsync(int id);
    }
}
