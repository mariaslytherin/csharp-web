using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                Points = points,
                Submissions = new List<Submission>()
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public List<Problem> GetAll()
        {
            return this.db.Problems.ToList();
        }

        public Problem GetProblemById(string id)
        {
            return this.db.Problems.FirstOrDefault(x => x.Id == id);
        }

        public int GetAllSubmissionsCountForThisProblem(string id)
        {
            var submission = this.db.Submissions
               .Include(x => x.Problem)
               .Include(x => x.User)
               .Where(x => x.ProblemId == id)
               .ToList();

            return submission.Count;
        }
    }
}
