using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        List<Problem> GetAll();

        Problem GetCurrentProblem(string name);

        List<Submission> GetAllSubmissionsForThisProblem(string problemName);
    }
}
