using TmaLib.Model;

namespace TmaLib.Repository
{
    public interface IEmployerRepository
    {
        Employer Add(Employer employer);
        List<Employer> GetAll();
        Task<Employer> GetById(int id);
        Employer Remove(Employer employer);
        Task SaveChanges();
        Employer Update(Employer employer);
    }
}