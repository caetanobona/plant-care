using AutoMapper;
using Microsoft.AspNetCore.Http;
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

            if (!result)
            {
                return NotFound();
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
            
            var createdUser = await _userService.CreateAsync(request);
            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            
            var updatedUser = await _userService.UpdateAsync(request);
            return Ok(updatedUser);
        }
        
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
