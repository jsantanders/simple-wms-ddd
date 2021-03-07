using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.AddressBooks.AddContact;
using ProjectName.Application.AddressBooks.DeleteContact;
using ProjectName.Application.AddressBooks.UpdateContactInfo;
using ProjectName.Application.SeedWork;

namespace ProjectName.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/v{version:apiVersion}/address-book")]
    public class AddressBookController : ControllerBase
    {
        private readonly IExecutor executor;

        public AddressBookController(IExecutor executor)
        {
            this.executor = executor;
        }

        [HttpPost("contacts")]
        public async Task<IActionResult> AddContact(
            [FromBody] AddContactCommand request)
        {
            Guid contactId = await executor.ExecuteCommandAsync(request);
            return Ok(new { id = contactId });
        }

        [HttpPatch("contacts/contact-info")]
        public async Task<IActionResult> UpdateContactInfo(
            [FromBody] UpdateContactInfoCommand request)
        {
            await executor.ExecuteCommandAsync(request);
            return Ok();
        }

        [HttpDelete("contacts/{contactId:Guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid contactId)
        {
            await executor.ExecuteCommandAsync(new DeleteContactCommand(contactId));
            return Ok();
        }
    }
}