using System.Collections.Generic;
using System.Linq;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public List<Problem> GetAll()
        {
            return this.db.Problems.ToList();
        }

        public Problem GetCurrentProblem(string name)
        {
            return this.db.Problems.FirstOrDefault(x => x.Name == name);
        }

        public List<Submission> GetAllSubmissionsForThisProblem(string problemName)
        {
            return this.db.Submissions.Where(x => x.Problem.Name == problemName).ToList();
        }
    }
}
