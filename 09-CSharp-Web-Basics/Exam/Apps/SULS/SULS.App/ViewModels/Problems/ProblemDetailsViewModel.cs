namespace SULS.App.ViewModels.Problems
{
    using SULS.App.ViewModels.Submissions;
    using System.Collections.Generic;

    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Submissions = new List<SubmissionAllViewModel>();
        }

        public string Name { get; set; }

        public ICollection<SubmissionAllViewModel> Submissions { get; set; }
    }
}
