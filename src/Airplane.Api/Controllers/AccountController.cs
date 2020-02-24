using System;
using System.Threading.Tasks;
using Airplane.Infrastructure.Commands.Users;
using Airplane.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airplane.Api.Controllers
{
    [Route("account")]
    public class AccountController : ApiControllerBase
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Json(await _userService.GetAccountAsync(UserId));
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Name, command.Surname,
                                            command.Email, command.Password, command.Role);

            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            var user = await _userService.LoginAsync(command.Email, command.Password);
            return Ok(user);
        }
    }
}