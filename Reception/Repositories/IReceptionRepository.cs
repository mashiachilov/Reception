using ReceptionApp.Models;
using System.Diagnostics.Eventing.Reader;

namespace ReceptionApp.Repositories
{
    public interface IReceptionRepository
    {
        Task<IEnumerable<Recept>> GetAllRecept();
        Task<Recept> GetSingleRecept(int id);
        Task CreateRecept(Recept recept);
        Task UpdateRecept(Recept recept);
        Task DeleteRecept(int id);
    }
}
