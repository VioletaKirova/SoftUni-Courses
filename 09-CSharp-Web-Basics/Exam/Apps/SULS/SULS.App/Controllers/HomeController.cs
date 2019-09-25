namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Home;
    using SULS.App.ViewModels.Problems;
    using SULS.Services;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var problems = this.problemService.GetAll();

                var viewModel = new ProblemIndexLoggedInViewModel();

                foreach (var problem in problems)
                {
                    viewModel.Problems.Add(new ProblemAllViewModel
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = problem.Submissions.Count
                    });
                }

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}