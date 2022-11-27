using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Repository;

namespace TeamManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }


        [HttpGet("GetMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            var result = await _teamMemberService.GetMembers();

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpGet("GetMember")]
        public async Task<IActionResult> GetMembers([FromHeader] int ID)
        {
            var result = await _teamMemberService.GetMember(ID);

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }


        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMember([FromForm] MemberBasicDataDTO member)
        {
            var result = await _teamMemberService.AddMember(member);

            if(result == false)
                return BadRequest();
            
            return Ok(result);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromForm] MemberBasicDataDTO member)
        {
            var result = await _teamMemberService.UpdateMember(member);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("DeleteMember")]

        public async Task<IActionResult> DeleteMember([FromBody] int ID)
        {
            var result = await _teamMemberService.DeleteMember(ID);
            return Ok(result);
        }

    }
}
