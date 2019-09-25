namespace FDMC.Services
{
    using FDMC.BindingModels;
    using FDMC.ViewModels;
    using System.Collections.Generic;

    public interface ICatService
    {
        IEnumerable<CatHomeViewModel> GetAll();

        CatDetailsVeiwModel GetById(string id);

        bool Add(CatAddBindingModel bindingModel);
    }
}
