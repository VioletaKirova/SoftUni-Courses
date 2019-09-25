namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.BindingModels.Problems;
    using SULS.App.ViewModels.Problems;
    using SULS.App.ViewModels.Submissions;
    using SULS.Models;
    using SULS.Services;

    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            Problem problem = new Problem
            {
                Name = model.Name,
                Points = model.Points
            };

            this.problemService.Create(problem);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problemFromDb = this.problemService.GetProblemById(id);
            
            var viewModel = new ProblemDetailsViewModel
            {
                Name = problemFromDb.Name
            };

            foreach (var submission in problemFromDb.Submissions)
            {
                viewModel.Submissions.Add(new SubmissionAllViewModel
                {
                    Username = submission.User.Username,
                    AchievedResult = submission.AchievedResult,
                    MaxPoints = problemFromDb.Points,
                    CreatedOn = submission.CreatedOn.ToString("dd/MM/yyyy"),
                    SubmissionId = submission.Id
                });
            }

            return this.View(viewModel);
        }

    }
}
