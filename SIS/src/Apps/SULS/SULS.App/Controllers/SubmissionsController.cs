using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.App.ViewModels.Users;
using SULS.Models;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;
        private readonly IUsersService usersService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService, IUsersService usersService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
            this.usersService = usersService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(ProblemHomeViewModel problemModel)
        {
            ProblemSubmissionViewModel model = new ProblemSubmissionViewModel
            {
                Name = problemModel.Name,
                ProblemId = problemModel.Id
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionInputModel submissionModel, ProblemHomeViewModel problemModel, LoginInputModel userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Submissions/Create");
            }

            Problem problem = this.problemsService.GetCurrentProblem(problemModel.Name);
            User user = this.usersService.GetUserOrNull(userModel.Username, userModel.Password);

            this.submissionsService.Create(user, problem, submissionModel.Code);

            return this.Redirect("/");
        }
    }
}
