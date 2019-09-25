namespace SULS.App.ViewModels.Home
{
    using SULS.App.ViewModels.Problems;
    using System.Collections.Generic;

    public class ProblemIndexLoggedInViewModel
    {
        public ProblemIndexLoggedInViewModel()
        {
            this.Problems = new List<ProblemAllViewModel>();
        }

        public ICollection<ProblemAllViewModel> Problems { get; set; }
    }
}
