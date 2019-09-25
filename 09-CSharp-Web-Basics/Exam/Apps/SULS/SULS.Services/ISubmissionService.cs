using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        Submission Create(Submission submission);

        bool Delete(string submissionId);
    }
}
