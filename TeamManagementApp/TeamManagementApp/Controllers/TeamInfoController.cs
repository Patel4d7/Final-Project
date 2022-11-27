using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;

namespace TeamManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamInfoController : ControllerBase
    {
        private readonly ITeamInfoService _teamInfoService;

        public TeamInfoController(ITeamInfoService teamInfoService)
        {
            _teamInfoService = teamInfoService;
        }

        [HttpGet("GetMembersInfo")]
        public async Task<IActionResult> GetMembersInfo()
        {
            var result = await _teamInfoService.GetMembersInfo();

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpGet("GetMember")]
        public async Task<IActionResult> GetMembers([FromHeader] int ID)
        {
            var result = await _teamInfoService.GetMember(ID);

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpPost("AddInfo")]
        public async Task<IActionResult> AddMemberInfo([FromHeader] int ID, [FromForm] MemberInfoDTO info)
        {
            var result = await _teamInfoService.AddMemberInfo(ID, info);

            if (result == false)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("UpdateInfo")]
        public async Task<IActionResult> UpdateMember([FromHeader] int ID, [FromForm] MemberInfoDTO info)
        {
            var result = await _teamInfoService.UpdateInfo(info, ID);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("DeleteInfo")]
        public async Task<IActionResult> DeleteInfo([FromHeader] int ID)
        {
            var result = await _teamInfoService.DeleteMemberInfo(ID);
            return Ok(result);
        }
    }
}
