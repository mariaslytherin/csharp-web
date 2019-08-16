using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Collections.Generic;
using System.Globalization;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.problemsService.Create(model.Name, model.Points);
            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemsService.GetProblemById(id);
            var allSubmissions = this.submissionsService.GetAllSubmissionsByProblemID(id);
            var allProblemSubmissions = new List<ProblemDetailsViewModel>();

            foreach (var submission in allSubmissions)
            {
                ProblemDetailsViewModel viewModel = new ProblemDetailsViewModel
                {
                    Username = submission.User.Username,
                    AchievedResult = submission.AchievedResult,
                    MaxPoints = problem.Points,
                    CreatedOn = submission.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    SubmissionId = submission.Id
                };

                allProblemSubmissions.Add(viewModel);
            }

            var dto = new AllProblemSubmissionsViewModel
            {
                Name = problem.Name,
                Submissions = allProblemSubmissions
            };

            return this.View(dto, "Details");
        }
    }
}
