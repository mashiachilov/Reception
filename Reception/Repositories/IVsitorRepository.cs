using ReceptionApp.Models;

namespace ReceptionApp.Repositories
{
    public interface IVsitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllVisitor();
        Task<Visitor> GetSingleVisitor(int id);
        Task CreateVisitor(Visitor visitor);
        Task UpdateVisitor(Visitor visitor);
        Task DeleteVisitor(int id);
    }
}
