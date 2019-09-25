using Messages.App.Models;
using Messages.Data;
using Messages.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagesDbContext dbContext;

        public MessagesController(MessagesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedOnAscending()
        {
            return this.dbContext.Messages
                .OrderBy(message => message.CreatedOn)
                .ToList();
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel messageCreateBindingModel)
        {
            var message = new Message
            {
                Content = messageCreateBindingModel.Content,
                User = messageCreateBindingModel.User,
                CreatedOn = DateTime.UtcNow
            };

            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();

            return this.Ok();
        }
    }
}
