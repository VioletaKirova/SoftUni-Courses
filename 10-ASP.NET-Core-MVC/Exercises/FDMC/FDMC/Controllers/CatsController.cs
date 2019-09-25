namespace FDMC.Controllers
{
    using FDMC.BindingModels;
    using FDMC.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : Controller
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        [HttpGet("/Cats/{id}")]
        public IActionResult Details(string id)
        {
            var viewModel = this.catService.GetById(id);

            return this.View(viewModel);
        }

        public IActionResult Add()
        {
            return this.View(new CatAddBindingModel());
        }

        [HttpPost]
        public IActionResult Add(CatAddBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel ?? new CatAddBindingModel());
            }

            this.catService.Add(bindingModel);

            return this.Redirect("/Home/Index");
        }
    }
}
