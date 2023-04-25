using UngeDrabanter.Models;

namespace UngeDrabanter.Interfaces
{
    public interface IUngeRepository
    {
        public User? GetUserById(Guid id);

        public User? GetUserByEmail(string email);

        public Guid CreateUser(User user);


        public Event? GetEventById(Guid id);

        public IEnumerable<Event> GetEventsByUserId(Guid userId);

        public Guid CreateEvent(Guid userId, Event eventObj);

        public bool SaveContext();
    }
}
