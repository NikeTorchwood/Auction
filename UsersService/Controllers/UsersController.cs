using Microsoft.AspNetCore.Mvc;
using UsersService.Services.ServicesAbstractions;

namespace UsersService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserService service) : ControllerBase
    {
        [HttpGet]
        [Route("CheckReservedEmail/{email}")]
        public async Task<ActionResult> CheckReservedEmail(string email)
        {
            var isReserved = await service.CheckReservedEmail(email);
            if (isReserved)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        [Route("CheckReservedUsername/{username}")]
        public async Task<ActionResult> CheckReservedUsername(string username)
        {
            var isReserved = await service.CheckReservedUsername(username);
            if (isReserved)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] UserCreateDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Invalid input data");
            }
            await service.RegisterUser(createDto);
            return Ok();
        }
    }

    public class UserCreateDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
