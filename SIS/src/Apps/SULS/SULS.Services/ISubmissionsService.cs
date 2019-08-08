using SULS.Models;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(User user, Problem problem, string code);
    }
}
