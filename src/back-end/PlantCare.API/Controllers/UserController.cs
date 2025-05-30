using Microsoft.AspNetCore.Mvc;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Application.Users.Models;
using PlantCare.Application.Users.Validators;

namespace Plantcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly IUserService _userService;
        private readonly CreateUserRequestValidator _createValidator;
        private readonly UpdateUserRequestValidator _updateValidator;

        public UserController(IUserService userService, CreateUserRequestValidator createValidator, UpdateUserRequestValidator updateValidator)
        {
            _userService = userService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _userService.DeleteAsync(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.ToList());
            }
            
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            
            var result = await _userService.CreateAsync(request);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.ToList());
            }
            
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            
            var result = await _userService.UpdateAsync(request);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.ToList());
            }
            
            return Ok(result.Value);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();

            if (result.Value is null)
            {
                return NotFound("No users found");
            }
            
            return Ok(result.Value);
        }
        
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var result = await _userService.GetByUsername(username);

            if (result.Value is null)
            {
                return NotFound("User not found");
            }
            
            return Ok(result.Value);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result.Value is null)
            {
                return NotFound("User not found");
            }
            
            return Ok(result.Value);
        }
        
    }
}
