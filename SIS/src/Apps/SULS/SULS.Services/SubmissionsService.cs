using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;
        private readonly IProblemsService problemsService;

        public SubmissionsService(SULSContext db, IProblemsService problemsService)
        {
            this.db = db;
            this.problemsService = problemsService;
        }

        public void CreateSubmissionAndAddToCurrentProblem(string userId, string problemId, string code)
        {
            Random result = new Random();
            var problem = this.problemsService.GetProblemById(problemId);

            var submission = new Submission
            {
                ProblemId = problemId,
                Code = code,
                AchievedResult = result.Next(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            problem.Submissions.Add(submission);
            this.db.Update(problem);
        }

        public ICollection<Submission> GetAllSubmissionsByProblemID(string problemId)
        {
            var submissions = this.db.Submissions
                .Include(x => x.Problem)
                .Include(x => x.User)
                .Where(x => x.ProblemId == problemId)
                .ToList();

            return submissions;
        }

        public bool DeleteSubmissionById(string id)
        {
            var submission = this.db.Submissions.SingleOrDefault(x => x.Id == id);


            this.db.Remove(submission);
            this.db.SaveChanges();

            return true;
        }
    }
}
