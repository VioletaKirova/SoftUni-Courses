namespace FDMC.Services
{
    using FDMC.BindingModels;
    using FDMC.Data;
    using FDMC.Models;
    using FDMC.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class CatService : ICatService
    {
        private readonly FdmcDbContext dbContext;

        public CatService(FdmcDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public IEnumerable<CatHomeViewModel> GetAll()
        {
            return this.dbContext.Cats.Select(cat => new CatHomeViewModel
            {
                Id = cat.Id,
                Name = cat.Name
            })
            .ToList();
        }

        public CatDetailsVeiwModel GetById(string id)
        {
            var catFromDb = this.dbContext.Cats.Find(id);

            var viewModel = new CatDetailsVeiwModel
            {
                Id = catFromDb.Id,
                Name = catFromDb.Name,
                Age = catFromDb.Age,
                Breed = catFromDb.Breed,
                ImageUrl = catFromDb.ImageUrl
            };

            return viewModel;
        }

        public bool Add(CatAddBindingModel bindingModel)
        {
            var cat = new Cat
            {
                Name = bindingModel.Name,
                Age = bindingModel.Age,
                Breed = bindingModel.Breed,
                ImageUrl = bindingModel.ImageUrl
            };

            this.dbContext.Cats.Add(cat);
            var result = this.dbContext.SaveChanges();

            return result == 1;
        }
    }
}
