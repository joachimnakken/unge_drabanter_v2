using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using UngeDrabanter.DtoModels;
using UngeDrabanter.Interfaces;
using UngeDrabanter.Models;

namespace UngeDrabanter.Controllers
{
    [Route("[controller]")]
    public class EventController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUngeRepository _repository;

        public EventController(IMapper mapper, IUngeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            var eventObject = _repository.GetEventById(id);
            if(eventObject != null)
            {
                return Ok(_mapper.Map<EventDto>(eventObject));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("User/{id}")]
        public IActionResult GetEventsByUser([FromRoute] Guid id)
        {
            var events = _repository.GetEventsByUserId(id);
            return Ok(events);
        }

        [HttpPost("User/{id}")]
        public IActionResult Post([FromRoute] Guid id,[FromBody] EventDto eventDto)
        {
            var eventId = _repository.CreateEvent(id, _mapper.Map<Event>(eventDto));

            if (_repository.SaveContext()) 
            {
                eventDto.EventId = eventId;
                return CreatedAtAction(nameof(EventController.Get), nameof(EventController).Replace("Controller", string.Empty), new { id = eventId }, eventDto);
            }
            else 
            { 
                return Conflict();
            }
        }

        //[HttpPut]
        //public IActionResult Put(EventDto eventDto)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
