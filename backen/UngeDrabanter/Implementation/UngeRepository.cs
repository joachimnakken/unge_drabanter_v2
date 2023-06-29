using Microsoft.EntityFrameworkCore;
using UngeDrabanter.DtoModels;
using UngeDrabanter.Interfaces;
using UngeDrabanter.Models;

namespace UngeDrabanter.Implementation
{
    public class UngeRepository : IUngeRepository
    {
        private readonly UngeDbContext _context;

        public UngeRepository(UngeDbContext context)
        {
            _context = context;
        }

        public Guid CreateEvent(Guid userId, Event eventObj)
        {
            Guid eventId = Guid.NewGuid();
            _context.Events.Add(new Event()
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
            _context.Users.Add(new User()
            {
                Id = userId,
                Email = user.Email,
                Name = user.Name,
            });
            return userId;
        }

        public Event? GetEventById(Guid id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventsByUserId(Guid userId)
        {
            return _context.Events.Where(e => e.UserHostId == userId).ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }


        public Session CreateSession(string sessionToken, Guid userId, DateTime expires)
        {
            var session = new Session()
            {
                Id = Guid.NewGuid(),
                Expires = expires,
                UserId = userId,
                SessionToken = sessionToken
            };
            _context.Sessions.Add(session);
            return session;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email))
                return null;

            if (await UserWithEmailExists(user.Email))
            {
                return null;
            }
            else
            {
                user.Id = Guid.NewGuid();
                _context.Users.Add(user);
                return user;
            }
        }

        public async Task<bool> DeleteSessionBySessionTokenAsync(string sessionToken)
        {
            var session = await _context.Sessions.Where(s => s.SessionToken == sessionToken).FirstOrDefaultAsync();
            if (session != null)
            {
                _context.Sessions.Remove(session);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<(Session session, User user)?> GetSessionAndUserBySessionTokenAsync(string sessionToken)
        {
            var result = await _context.Sessions.Where(s => s.SessionToken == sessionToken)
                .Select(s => new { session = s, user = s.User }).FirstOrDefaultAsync();
            if (result != null)
            {
                return (result.session, result.user);
            }
            else
            {
                return null;
            }
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByAccountAsync(string providerAccountId, string provider)
        {
            if (string.IsNullOrEmpty(providerAccountId) || string.IsNullOrEmpty(provider))
                return null;
            else
            {
                return await _context.Accounts.Where(a => a.ProviderAccountId == providerAccountId)
                    .Where(a => a.Provider == provider)
                    .Select(a => a.User)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return await Task.FromResult<User?>(null);
            }
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public bool AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() != 0);

        }

        public async Task<bool> UpdateSessionAsync(Session session)
        {
            var targetSession = await _context.Sessions.FirstOrDefaultAsync(s => s.SessionToken == session.SessionToken);
            if (targetSession == null)
            {
                return false;
            }
            else
            {
                targetSession.Expires = session.Expires;
                return true;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null)
                return false;
            var targetUser = await GetUserAsync(user.Id);
            if (targetUser == null)
                return false;
            targetUser.Email = user.Email;
            targetUser.Name = user.Name;
            targetUser.EmailVerified = user.EmailVerified;
            return true;
        }


        private Task<bool> UserWithEmailExists(string email)
        {
            if (email == null)
                return Task.FromResult(false);
            return _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<(Session session, User user)?> GetSessionAndUserBySessionIdAsync(Guid id)
        {
            var result = await _context.Sessions.Where(s => s.Id == id)
                            .Select(s => new { session = s, user = s.User }).FirstOrDefaultAsync();
            if (result != null)
            {
                return (result.session, result.user);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteSessionByIdAsync(Guid id)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> RemoveAccount(Guid userId, string provider)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == userId && a.Provider == provider);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                return true;
            }
            return false;
        }

        public async Task<SessionValidatorDto?> ValidateSessionAsync(string sessionToken, string provider)
        {
            return await _context.Sessions.Where(s => s.SessionToken == sessionToken)
                .SelectMany(s => s.User.Accounts)
                .Where(a => a.Provider == provider)
                .Select(a => new SessionValidatorDto()
                {
                    Provider = provider,
                    ProviderAccountId = a.ProviderAccountId,
                    UserId = a.UserId,
                }).FirstOrDefaultAsync();
        }
    }
}
