using UngeDrabanter.DtoModels;
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

        Task<User?> CreateUserAsync(User user);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserAsync(Guid id);

        Task<bool> UpdateUserAsync(User user);

        bool AddAccount(Account account);

        Task<bool> RemoveAccount(Guid userId, string provider);

        Task<User?> GetUserByAccountAsync(string providerAccountId, string provider);

        Session CreateSession(string sessionToken, Guid userId, DateTime expires);

        Task<bool> UpdateSessionAsync(Session session);

        Task<bool> DeleteSessionBySessionTokenAsync(string sessionToken);
        Task<bool> DeleteSessionByIdAsync(Guid id);

        Task<(Session session, User user)?> GetSessionAndUserBySessionTokenAsync(string sessionToken);
        Task<(Session session, User user)?> GetSessionAndUserBySessionIdAsync(Guid id);
        Task<SessionValidatorDto> ValidateSessionAsync(string sessionToken, string provider);

        Task<bool> SaveChangesAsync();
    }
}
