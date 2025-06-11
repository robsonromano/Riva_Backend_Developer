using Bogus;
using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Domain.Enums;

namespace IntelSyncStarter.Seeder
{
    public class FakeDataSeeder
    {
        private readonly IUserService _userService;

        public FakeDataSeeder(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SeedUsersAsync(int count)
        {
            var faker = new Faker<CrmUser>()
                .RuleFor(u => u.Id, f => 0) // Deixa o Id 0 para banco gerar, ou configure de acordo com seu repositório
                .RuleFor(u => u.UserName, f => f.Internet.Email())
                .RuleFor(u => u.CrmPlatform, f => f.PickRandom<CrmPlatform>())
                .RuleFor(u => u.CrmToken, f => f.Random.AlphaNumeric(10))
                .RuleFor(u => u.ObjectType, f => f.PickRandom<ObjectType>())
                .RuleFor(u => u.Payload, f => $"{{ \"email\": \"{f.Internet.Email()}\", \"name\": \"{f.Name.FirstName()}\" }}");

            for (int i = 0; i < count; i++)
            {
                var fakeUser = faker.Generate();
                await _userService.AddAsync(fakeUser);
            }
        }
    }
}
