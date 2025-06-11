using IntelSyncStarter.Business.Implementations;
using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntelSyncStarter.Test
{
    [TestFixture]
    public class ValidateTokenTests
    {
        private ISyncValidator<CrmUser> _tokenValidation;

        [SetUp]
        public void Setup()
        {
            var service = new ServiceCollection();
            service.AddTransient<ISyncValidator<CrmUser>, SimpleTokenValidator>();

            var provider = service.BuildServiceProvider();
            _tokenValidation = provider.GetService<ISyncValidator<CrmUser>>();
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Check_Empty_Token(string token)
        {
            var result = _tokenValidation.Validate(new() { CrmToken = token });

            Assert.That(result.Status, Is.EqualTo(SyncStatus.Fail));
            Assert.That(result.ErrorMessage, Is.EqualTo("Missing CRM token"));
        }

        [Test]
        public void Check_Valid_Token()
        {
            var result = _tokenValidation.Validate(new() { CrmToken = "123423423" });

            Assert.That(result.Status, Is.EqualTo(SyncStatus.Success));
            Assert.That(result.ErrorMessage, Is.Null);
        }
    }
}
