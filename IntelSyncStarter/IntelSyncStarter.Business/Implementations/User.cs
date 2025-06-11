using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace IntelSyncStarter.Business.Implementations
{
    /// <summary>
    /// Service responsible for user-related operations.
    /// Implements the <see cref="IUser"/> interface.
    /// </summary>
    public class User: IUser
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructs the service with required repository dependency.
        /// </summary>
        /// <param name="userRepository">The repository used to manage user data.</param>
        public User(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Adds a new CRM user to the system.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <exception cref="ValidationException">Thrown if the provided user is null.</exception>
        public async Task AddAsync(CrmUser user)
        {
            if (user == null)
                throw new ValidationException("User invalid.");

            await _userRepository.AddAsync(user);
        }

        /// <summary>
        /// Retrieves a CRM user by their unique identifier.
        /// </summary>
        /// <param name="UserId">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="CrmUser"/> instance if found; otherwise, <c>null</c>.</returns>
        public async Task<CrmUser?> GetUserAsync(int UserId)
        {
            return await _userRepository.GetUserAsync(UserId);
        }
    }
}
