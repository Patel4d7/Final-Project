using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;

namespace TeamManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _markService;

        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }

        [HttpGet("GetMembersMarks")]
        public async Task<IActionResult> GetMembersMarks()
        {
            var result = await _markService.GetMarks();

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpGet("GetMemberMarks")]
        public async Task<IActionResult> GetMemberMarks([FromHeader] int ID)
        {
            var result = await _markService.GetMemberMarks(ID);

            if (result == null)
                return new NoContentResult();
            return Ok(result);
        }

        [HttpPost("AddMarks")]
        public async Task<IActionResult> AddMemberInfo([FromHeader] int ID, [FromForm] MarksDTO marks)
        {
            var result = await _markService.AddMarks(ID, marks);

            if (result == false)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("UpdateMarks")]
        public async Task<IActionResult> UpdateMarks([FromHeader] int ID, [FromForm] MarksDTO marks)
        {
            var result = await _markService.UpdateMarks(marks, ID);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("DeleteMarks")]
        public async Task<IActionResult> DeleteMarks([FromHeader] int ID)
        {
            var result = await _markService.DeleteMarks(ID);
            return Ok(result);
        }
    }
}
