using IntelSyncStarter.Services;
using NUnit.Framework;

namespace IntelSyncStarter.Tests;

public class IntelSyncProcessorTests
{
    [Test]
    public void ProcessSyncJobs_ShouldRunWithoutExceptions()
    {
        var processor = new IntelSyncProcessor();
        processor.ProcessSyncJobs();
        Assert.Pass("Processor executed without throwing exceptions.");
    }
}
