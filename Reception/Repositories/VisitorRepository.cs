using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data;
using ReceptionApp.Models;

namespace ReceptionApp.Repositories
{
    public class VisitorRepository : IVsitorRepository
    {
        public VisitorRepository(ReceptionAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ReceptionAppDbContext DbContext { get; }

        public async Task DeleteVisitor(int id)
        {
            var visitor = await DbContext.Visitors.FirstOrDefaultAsync(v => v.Id == id);

            if (visitor != null)
            {
                DbContext.Visitors.Remove(visitor);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<Visitor> GetSingleVisitor(int id)
        {
            return await DbContext.Visitors.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitor()
        {
            return await DbContext.Visitors.ToListAsync();
        }

        public async Task CreateVisitor(Visitor visitor)
        {
            await DbContext.Visitors.AddAsync(visitor);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateVisitor(Visitor visitor)
        {
            DbContext.Entry(visitor).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
