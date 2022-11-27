using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;

namespace TeamManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;

        public InterestController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet("GetMembersInterest")]
        public async Task<IActionResult> GetMembersInterest()
        {
            var result = await _interestService.GetMembersInterests();

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpGet("GetMemberInterest")]
        public async Task<IActionResult> GetMemberInterest([FromHeader] int ID)
        {
            var result = await _interestService.GetMemberInterest(ID);

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpPost("AddInterests")]
        public async Task<IActionResult> AddMemberInfo([FromHeader] int ID, [FromForm] InterestDTO interest)
        {
            var result = await _interestService.AddInterest(ID, interest);

            if (result == false)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("UpdateInterest")]
        public async Task<IActionResult> UpdateInterest([FromHeader] int ID, [FromForm] InterestDTO interest)
        {
            var result = await _interestService.UpdateInterest(interest, ID);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("DeleteInterest")]
        public async Task<IActionResult> DeleteInterst([FromHeader] int ID)
        {
            var result = await _interestService.DeleteMembersInterest(ID);
            return Ok(result);
        }
    }
}
