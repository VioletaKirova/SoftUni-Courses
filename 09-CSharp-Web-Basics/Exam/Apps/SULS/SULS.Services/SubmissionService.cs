using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext dbContext;

        public SubmissionService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Submission Create(Submission submission)
        {
            var submissionFromDb = this.dbContext.Submissions.Add(submission).Entity;
            this.dbContext.SaveChanges();

            return submissionFromDb;
        }

        public bool Delete(string submissionId)
        {
            var submissionFromDb = this.dbContext.Submissions
                .SingleOrDefault(submission => submission.Id == submissionId);

            this.dbContext.Submissions.Remove(submissionFromDb);
            this.dbContext.SaveChanges();

            return true;
        }
    }
}
