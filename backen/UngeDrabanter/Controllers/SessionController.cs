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
    public class SessionController : ControllerBase
    {
        private readonly IUngeRepository _ungeRepository;
        private readonly IMapper _mapper;

        public SessionController(IUngeRepository authenticationRepository, IMapper mapper)
        {
            _ungeRepository = authenticationRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SessionDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            var userAndSession = await _ungeRepository.GetSessionAndUserBySessionIdAsync(id);
            if (userAndSession.HasValue)
            {
                return Ok(new
                {
                    user = _mapper.Map<UserDto>(userAndSession.Value.user),
                    session = _mapper.Map<SessionDto>(userAndSession.Value.session),
                });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SessionDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([Required] Guid id, [FromBody][Required] SessionDto session)
        {
            session.Id = id;
            var result = await _ungeRepository.UpdateSessionAsync(_mapper.Map<Session>(session));
            if (!result)
            {
                return NotFound(session);
            }

            if (await _ungeRepository.SaveChangesAsync())
            {
                return Ok();
            }
            else
            {
                return Conflict(session);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _ungeRepository.DeleteSessionByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }
            await _ungeRepository.SaveChangesAsync();
            return NoContent();

        }
    }
}
