using Microsoft.AspNetCore.Mvc;
using RestApi_MongoDB.Models;
using RestApi_MongoDB.Services;

namespace RestApi_MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(User user)
        {
            return Ok(await _userService.InsertAsync(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, User value)
        {
            return Ok(await _userService.UpdateAsync(id, value));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }
    }
}