namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.BindingModels.Submissions;
    using SULS.App.ViewModels.Submissions;
    using SULS.Models;
    using SULS.Services;
    using System;

    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;

        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetProblemById(id);

            var viewModel = new SubmissionCreateViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(SubmissionCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={model.ProblemId}");
            }

            var random = new Random();
            var problemTotalPoints = this.problemService.GetProblemById(model.ProblemId).Points;

            var submission = new Submission
            {
                Code = model.Code,
                AchievedResult = random.Next(0, problemTotalPoints),
                CreatedOn = DateTime.UtcNow,
                ProblemId = model.ProblemId,
                UserId = this.User.Id
            };

            this.submissionService.Create(submission);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionService.Delete(id);

            return this.Redirect("/");
        }
    }
}
