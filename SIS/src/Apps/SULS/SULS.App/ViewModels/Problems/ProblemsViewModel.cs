using SULS.Models;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemsViewModel
    {
        public ProblemsViewModel()
        {
            this.Problems = new List<ProblemHomeViewModel>();
        }

        public List<ProblemHomeViewModel> Problems { get; set; }
    }
}
