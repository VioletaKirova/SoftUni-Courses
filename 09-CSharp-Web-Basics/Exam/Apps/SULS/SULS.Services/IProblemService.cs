using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IProblemService
    {
        Problem Create(Problem problem);

        ICollection<Problem> GetAll();

        Problem GetProblemById(string id);
    }
}
