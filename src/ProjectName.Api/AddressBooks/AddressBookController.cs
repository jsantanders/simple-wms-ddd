using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.AddressBooks.AddContact;
using ProjectName.Application.SeedWork;

namespace ProjectName.Api.AddressBooks
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
            return Ok();
        }

        public async Task<IActionResult> UpdateContactInfo(
            [FromRoute] Guid contactId,
            [FromBody] UpdateContactInfoRequest request)
        {
            return Ok();
        }

        [HttpDelete("contacts")]
        public async Task<IActionResult> DeleteContact()
        {
            return Ok();
        }
    }
}