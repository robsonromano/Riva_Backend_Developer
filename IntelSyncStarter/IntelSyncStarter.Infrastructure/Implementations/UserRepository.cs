using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Infrastructure.Interfaces;

namespace IntelSyncStarter.Infrastructure.Implementations
{
    /// <summary>
    /// Manage the access on User storage (e.g. database)
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private static readonly List<CrmUser> _user = [];

        public async Task AddAsync(CrmUser user)
        {
            await Task.Delay(1); //Simulates database access
            _user.Add(user);
        }

        public async Task<IEnumerable<CrmUser>> GetAllAsync()
        {
            await Task.Delay(5); //Simulates database access
            return _user;
        }

        public async Task<CrmUser?> GetUserAsync(int userId)
        {
            await Task.Delay(1); //Simulates database access
            return _user.Where(item => item.Id == userId).FirstOrDefault();
        }
    }
}
