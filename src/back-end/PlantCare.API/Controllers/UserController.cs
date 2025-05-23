using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantCare.Application.Users.Interfaces;

namespace Plantcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
git 
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Console.WriteLine("User GetAllAsync Request");
            
            return Ok(await _userService.GetAllAsync());
        }
        
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var user = await _userService.GetByUsername(username);

            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
        
    }
}
