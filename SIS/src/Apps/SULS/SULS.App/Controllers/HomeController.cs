using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        // /Home/Index
        public IActionResult Index()
         {
            ProblemsViewModel problemsViewModel = new ProblemsViewModel();

            if (this.IsLoggedIn())
            {
                var countOfSubmissions = 0;
                var problems = this.problemsService.GetAll();

                foreach (var problem in problems)
                {
                    countOfSubmissions = this.problemsService.GetAllSubmissionsForThisProblem(problem.Name).ToList().Count;

                    ProblemHomeViewModel currentProblem = new ProblemHomeViewModel
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = countOfSubmissions
                    };

                    problemsViewModel.Problems.Add(currentProblem);
                }

                return this.View(problemsViewModel, "IndexLoggedIn");
            }

            return this.View("Index");
        }
    }
}
