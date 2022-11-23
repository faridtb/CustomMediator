using CustomMediatr.Api.Command.Queries;
using CustomMediatr.Api.Models;
using CustomMediatr.Api.Query.Queries;
using CustomMediatr.Library.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediatr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<UserViewModel> Get()
        {
            return await mediator.Send(new GetUserByIdQuery(1));
        }

        [HttpPut]
        public async Task<int> Update()
        {
            return await mediator.Send(new UsernameUpdateCommand("admin"));
        }
    }
}
