using SULS.Models;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class AllProblemSubmissionsViewModel
    {
        public string Name { get; set; }

        public List<ProblemDetailsViewModel> Submissions { get; set; }
    }
}
