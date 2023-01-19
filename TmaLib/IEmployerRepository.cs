using TmaLib.Model;

namespace TmaLib
{
    public interface IEmployerRepository
    {
        Employer Add(Employer employer);
        Task<Employer> GetById(int id);
        Employer Remove(Employer employer);
        Employer Update(Employer employer);
    }
}