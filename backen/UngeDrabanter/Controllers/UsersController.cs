using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UngeDrabanter.DtoModels;
using UngeDrabanter.Interfaces;
using UngeDrabanter.Models;

namespace UngeDrabanter.Controllers
{
    [ApiController]
    [Route("/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUngeRepository _ungeRepository;
        private readonly IMapper _mapper;

        public UsersController(IUngeRepository authenticationRepository, IMapper mapper)
        {
            _ungeRepository = authenticationRepository;
            _mapper = mapper;
        }



        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody][Required] UserDto user)
        {
            var result = await _ungeRepository.CreateUserAsync(_mapper.Map<User>(user));
            if (result == null)
            {
                return Conflict();
            }
            if (await _ungeRepository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(UserController.GetUser), nameof(UserController).Replace("Controller", string.Empty), new { id = result.Id }, result);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateUserAsync([FromBody][Required] UserDto user)
        {
            var result = await _ungeRepository.UpdateUserAsync(_mapper.Map<User>(user));
            if (!result)
            {
                return NotFound();
            }
            if (await _ungeRepository.SaveChangesAsync())
            {
                return Ok(user);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByEmailAsync([FromQuery][EmailAddress] string? email, [FromQuery] string? providerAccountId, [FromQuery] string? provider)
        {
            if (string.IsNullOrEmpty(email))
            {
                if (!string.IsNullOrEmpty(providerAccountId) && !string.IsNullOrEmpty(provider))
                {
                    return await GetUserByAccountInformationAsync(providerAccountId, provider);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(providerAccountId) && string.IsNullOrEmpty(provider))
                {
                    return await GetUserByEmailAsync(email);
                }
            }
            return BadRequest();
        }

        private async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            var result = await _ungeRepository.GetUserByEmailAsync(email);
            if (result != null)
            {
                return Ok(new[] { _mapper.Map<UserDto>(result) });
            }
            else
            {
                return Ok(Enumerable.Empty<UserDto>());
            }
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        private async Task<IActionResult> GetUserByAccountInformationAsync(string providersAccountId, string provider)
        {
            var result = await _ungeRepository.GetUserByAccountAsync(providersAccountId, provider);
            if (result != null)
            {
                return Ok(new[] { _mapper.Map<UserDto>(result) });
            }
            else
            {
                return Ok(Enumerable.Empty<UserDto>());
            }
        }


    }
}
