using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemsService.GetProblemById(id);

            ProblemSubmissionViewModel model = new ProblemSubmissionViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionInputModel submissionModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={submissionModel.ProblemId}");
            }

            this.submissionsService.CreateSubmissionAndAddToCurrentProblem(this.User.Id, submissionModel.ProblemId, submissionModel.Code);

            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionsService.DeleteSubmissionById(id);

            return this.Redirect("/");
        }
    }
}
