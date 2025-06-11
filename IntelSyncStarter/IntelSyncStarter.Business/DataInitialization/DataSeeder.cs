using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Domain.Enums;

namespace IntelSyncStarter.Business.DataInitialization
{
    /// <summary>
    /// Class responsible for seeding initial or fake data into the system
    /// </summary>
    public class DataSeeder
    {
        private readonly IUser _userService;
        private readonly ISyncJobs _syncJobsService;

        public DataSeeder(IUser userService, ISyncJobs syncJobsService)
        {
            _userService = userService;
            _syncJobsService = syncJobsService;
        }

        public async Task SeedAsync()
        {
            await SeedUserAsync();
            await SeedSyncJobsAsync();
        }

        private async Task SeedUserAsync()
        {
            await _userService.AddAsync(new()
            {
                Id = 1,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "alice@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 2,
                CrmPlatform = CrmPlatform.Outlook,
                Email = "bob@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 3,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "conor@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 4,
                CrmPlatform = CrmPlatform.Outlook,
                Email = "sarah@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 5,
                CrmPlatform = CrmPlatform.Outlook,
                Email = "amanda@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 6,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "emily@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 7,
                CrmPlatform = CrmPlatform.Outlook,
                Email = "liam@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 8,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "stella@example.com",
                CrmToken = "token123",
            });
            await _userService.AddAsync(new()
            {
                Id = 9,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "seb@example.com",
                CrmToken = "",
            });
            await _userService.AddAsync(new()
            {
                Id = 10,
                CrmPlatform = CrmPlatform.Salesforce,
                Email = "noah@example.com",
                CrmToken = "token123",
            });
        }

        private async Task SeedSyncJobsAsync()
        {
            Random random = new Random();

            for (int i = 1; i <= 100; i++)
                await _syncJobsService.AddAsync(new()
                {
                    Id = i,
                    UserId = random.Next(1, 11),
                    ObjectType = random.Next(1, 2) % 2 == 0 ? ObjectType.Contact : ObjectType.Meeting,
                    Payload = await CreatePayloadAsync(i),
                });
        }

        private async Task<string> CreatePayloadAsync(int userId)
        {
            CrmUser? user = await _userService.GetUserAsync(userId);

            return user != null ? $"{{ \"email\": \"{user.Email}\" }}" : "";
        }
    }
}
