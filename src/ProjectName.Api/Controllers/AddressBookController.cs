using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.AddressBooks.AddContact;
using ProjectName.Application.SeedWork;

namespace ProjectName.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/v{version:apiVersion}/addressbook")]
    public class AddressBookController : ControllerBase
    {
        private readonly IExecutor executor;

        public AddressBookController(IExecutor executor)
        {
            this.executor = executor;
        }

        [HttpPost("contacts")]
        public async Task<IActionResult> AddContactAsync(
            [FromBody] AddContactCommand request)
        {
            return Ok();
        }

        [HttpDelete("contacts")]
        public async Task<IActionResult> DeleteContactAsync()
        {
            return Ok();
        }
    }
}