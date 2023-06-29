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
    public class UserController : ControllerBase
    {
        private readonly IUngeRepository _ungeRepository;
        private readonly IMapper _mapper;

        public UserController(IUngeRepository authenticationRepository, IMapper mapper)
        {
            _ungeRepository = authenticationRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _ungeRepository.GetUserAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<UserDto>(result));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateUserAsync(Guid id, [FromBody][Required] UserDto user)
        {
            user.Id = id;
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

        [HttpPost("{id}/Accounts")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LinkAccountAsync(Guid id, [FromBody] AccountDto account)
        {
            account.UserId = id;
            _ungeRepository.AddAccount(_mapper.Map<Account>(account));
            if (await _ungeRepository.SaveChangesAsync())
            {
                return Ok(account);
            }
            else
            {
                return Conflict();
            }
        }


        [HttpDelete("{id}/Accounts/{provider}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UnlinkAccountAsync(Guid id, string provider)
        {
            var result = await _ungeRepository.RemoveAccount(id, provider);
            if (!result)
            {
                return NotFound();
            }
            if (await _ungeRepository.SaveChangesAsync())
            {
                return NoContent();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
