using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data;
using ReceptionApp.Models;

namespace ReceptionApp.Repositories
{
    public class ReceptRepository : IReceptionRepository
    {
        public ReceptRepository(ReceptionAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ReceptionAppDbContext DbContext { get; }

        public async Task CreateRecept(Recept recept)
        {
            await DbContext.Receptions.AddAsync(recept);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteRecept(int id)
        {
            var recept = await DbContext.Receptions.FirstOrDefaultAsync(r => r.Id == id);
            if(recept != null)
            {
                DbContext.Receptions.Remove(recept);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Recept>> GetAllRecept()
        { 
            var recepts = await DbContext.Receptions.ToListAsync();
            return recepts;
        }

        public async Task<Recept> GetSingleRecept(int id)
        {
            return await DbContext.Receptions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateRecept(Recept recept)
        {
            DbContext.Entry(recept).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}
