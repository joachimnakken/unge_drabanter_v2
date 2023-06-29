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
    public class SessionsController : ControllerBase
    {
        private readonly IUngeRepository _ungeRepository;
        private readonly IMapper _mapper;

        public SessionsController(IUngeRepository authenticationRepository, IMapper mapper)
        {
            _ungeRepository = authenticationRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody][Required] SessionDto session)
        {
            var result = _ungeRepository.CreateSession(session.SessionToken, session.UserId, session.Expires);
            if (await _ungeRepository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(SessionsController.Get), nameof(SessionsController).Replace("Controller", ""), new { sessionToken = session.SessionToken }, _mapper.Map<SessionDto>(result));
            }
            else
            {
                return Conflict();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionAndUserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery][Required] string sessionToken)
        {
            var result = await _ungeRepository.GetSessionAndUserBySessionTokenAsync(sessionToken);
            if (!result.HasValue)
            {
                return Ok(Enumerable.Empty<SessionAndUserDto>());
            }
            else
            {
                return Ok(new[] {
                    new SessionAndUserDto(){
                        Session = _mapper.Map<SessionDto>(result.Value.session),
                        User = _mapper.Map<UserDto>(result.Value.user)
                    }
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(SessionDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromBody][Required] SessionDto session)
        {
            var result = await _ungeRepository.UpdateSessionAsync(_mapper.Map<Session>(session));
            if (!result)
            {
                return NotFound();
            }

            if (await _ungeRepository.SaveChangesAsync())
            {
                return Ok(session);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromQuery][Required] string sessionToken)
        {
            var result = await _ungeRepository.DeleteSessionBySessionTokenAsync(sessionToken);
            if (!result)
            {
                return NotFound();
            }
            await _ungeRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
