using UngeDrabanter.Interfaces;
using UngeDrabanter.Models;

namespace UngeDrabanter.Implementation
{
    public class UngeRepository : IUngeRepository
    {
        private readonly UngeDbContext _dbContext;

        public UngeRepository(UngeDbContext context)
        {
            _dbContext = context;
        }

        public Guid CreateEvent(Guid userId, Event eventObj)
        {
            Guid eventId = Guid.NewGuid();
            _dbContext.Events.Add(new Event()
            {
                EventCode = "000000",
                Id = eventId,
                EventDateTime = eventObj.EventDateTime,
                Name = eventObj.Name,
                UserHostId = userId,
                EventUri = eventObj.EventUri,
                ImageUri = eventObj.ImageUri,
            });
            return eventId;
        }

        public Guid CreateUser(User user)
        {
            Guid userId = Guid.NewGuid();
            _dbContext.Users.Add(new User()
            {
                Id = userId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
            return userId;
        }

        public Event? GetEventById(Guid id)
        {
            return _dbContext.Events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventsByUserId(Guid userId)
        {
            return _dbContext.Events.Where(e => e.UserHostId == userId).ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool SaveContext()
        {
            return _dbContext.SaveChanges() != 0;
        }
    }
}
