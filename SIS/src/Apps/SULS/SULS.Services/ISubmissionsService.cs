using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void CreateSubmissionAndAddToCurrentProblem(string userId, string problemId, string code);

        ICollection<Submission> GetAllSubmissionsByProblemID(string problemId);

        bool DeleteSubmissionById(string id);
    }
}
