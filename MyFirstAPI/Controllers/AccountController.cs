using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.DTO;
using MyFirstAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        //ActionResult -> returns the status of the operation (ex: action failed/succeeded)
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO dto)
        {
            if (await _service.UserExists(dto.Name))
            {
                return BadRequest("Username already exists");
                //Badresult -> part of the ActionResult
            }
            return await _service.RegisterAsync(dto.Name, dto.Password);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> LoginAsync(LoginDTO dto)
        {
            try
            {
                UserDTO user = await _service.LoginAsync(dto.Name, dto.Password);

                return user;
            }
            catch (UnauthorizedAccessException e)
            {

                return Unauthorized(e.Message);
            }
            
        }
        
    }
}
