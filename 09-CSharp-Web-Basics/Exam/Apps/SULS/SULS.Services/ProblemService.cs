using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext dbContext;

        private readonly IUserService userService;

        public ProblemService(SULSContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public Problem Create(Problem problem)
        {
            var problemFromDb = this.dbContext.Problems.Add(problem).Entity;
            this.dbContext.SaveChanges();

            return problemFromDb;
        }

        public ICollection<Problem> GetAll()
        {
            return this.dbContext.Problems
                .Include(problem => problem.Submissions)
                .ToList();
        }

        public Problem GetProblemById(string id)
        {
            return this.dbContext.Problems
                .Include(problem => problem.Submissions)
                .ThenInclude(submission => submission.User)
                .SingleOrDefault(problem => problem.Id == id);
        }
    }
}
