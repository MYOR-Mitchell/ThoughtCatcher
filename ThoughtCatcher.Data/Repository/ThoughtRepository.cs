using Microsoft.EntityFrameworkCore;
using ThoughtCatcher.Core.Interfaces;
using ThoughtCatcher.Core.Models;

namespace ThoughtCatcher.Data.Repository
{
    public class ThoughtRepository : IThoughtRepository
    {
        private readonly ThoughtCatcherDbContext _context;

        public ThoughtRepository(ThoughtCatcherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Thought>> GetAllAsync()
        {
            return await _context.ThoughtCatcher
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }

        public async Task<Thought?> GetByIdAsync(int id)
        {
            return await _context.ThoughtCatcher.FindAsync(id);
        }

        public async Task AddAsync(Thought thought)
        {
            _context.ThoughtCatcher.Add(thought);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Thought thought)
        {
            var existingThought = await _context.ThoughtCatcher.FindAsync(thought.Id);
            if(existingThought == null)
                return;

            existingThought.Title = thought.Title;
            existingThought.Body = thought.Body;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var thought = await _context.ThoughtCatcher.FindAsync(id);
            if(thought is not null)
            {
                _context.ThoughtCatcher.Remove(thought);
                await _context.SaveChangesAsync();
            }
        }
    }
}
