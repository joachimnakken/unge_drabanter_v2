using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UngeDrabanter.DtoModels;
using UngeDrabanter.Interfaces;
using UngeDrabanter.Models;

namespace UngeDrabanter.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUngeRepository _repository;

        public UserController(IMapper mapper, IUngeRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            var user = _repository.GetUserById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            Guid UserId = _repository.CreateUser(_mapper.Map<User>(user));
            if (_repository.SaveContext())
            {
                return CreatedAtAction(nameof(UserController.Get), nameof(UserController).Replace("Controller", string.Empty), new { id = UserId }, user);
            }
            else
            {
                return Conflict();
            }
        }

        //[HttpPut]
        //public IActionResult Put([FromBody] UserDto id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
