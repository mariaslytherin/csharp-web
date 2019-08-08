using SULS.Data;
using SULS.Models;
using System;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;

        public SubmissionsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(User user, Problem problem, string code)
        {
            Random result = new Random();

            var submission = new Submission
            {
                Problem = problem,
                Code = code,
                AchievedResult = result.Next(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                User = user
            };

            this.db.Add(submission);
            this.db.SaveChanges();
        }
    }
}
