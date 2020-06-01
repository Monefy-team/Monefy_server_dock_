using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.DTO;
using WebAPI.BLL.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto dto)
        {
            await _userService.CreateAsync(dto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(string id)
        {
            return await _userService.GetAsync(id);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CreateUserDto dto,string id)
        {
            await _userService.UpdateAsync(dto,id);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            await _userService.RemoveAsync(id);
            return NoContent();
        }
    }
}