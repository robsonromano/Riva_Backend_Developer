using IntelSyncStarter.Business.Implementations;
using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace IntelSyncStarter.Test
{
    [TestFixture]
    public class BatchSyncProcessorServiceTests
    {
        private Mock<ISyncJobs> _syncJobsServiceMock;
        private Mock<ISyncValidator<CrmUser>> _validatorMock;
        private BatchSyncProcessor _service;

        [SetUp]
        public void SetUp()
        {
            _syncJobsServiceMock = new Mock<ISyncJobs>();
            _validatorMock = new Mock<ISyncValidator<CrmUser>>();

            var settings = Options.Create(new AppSettings
            {
                BatchSize = 2,
                ParallelProcess = 1
            });

            _service = new BatchSyncProcessor(
                _syncJobsServiceMock.Object,
                _validatorMock.Object,
                settings
            );
        }

        [Test]
        public async Task ProcessSyncJobsAsync_UpdatesStatus_ForEachJob()
        {
            // Arrange
            var users = new List<CrmUser>
            {
                new CrmUser { Id = 1, Email = "alice@example.com" },
                new CrmUser { Id = 2, Email = "bob@example.com" }
            };

            var jobs = new List<SyncJobTask>
            {
                new SyncJobTask
                {
                    SyncJob = new SyncJob { Id = 1, UserId = 1 },
                    User = users[0]
                },
                new SyncJobTask
                {
                    SyncJob = new SyncJob { Id = 2, UserId = 2 },
                    User = users[1]
                }
            };

            _syncJobsServiceMock.SetupSequence(s => s.GetAllPendingAsync(It.IsAny<int>()))
                .ReturnsAsync(jobs)
                .ReturnsAsync(new List<SyncJobTask>());

            _validatorMock.Setup(v => v.Validate(It.IsAny<CrmUser>()))
                .Returns((CrmUser u) => TokenValidationResult.Success());

            await _service.ProcessSyncJobsAsync();

            _syncJobsServiceMock.Verify(s => s.UpdateStatusAsync(It.IsAny<SyncJob>()), Times.Exactly(2));
        }
    }
}