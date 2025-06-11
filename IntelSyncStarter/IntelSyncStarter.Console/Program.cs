// See https://aka.ms/new-console-template for more information

using IntelSyncStarter.Business.DataInitialization;
using IntelSyncStarter.Business.Implementations;
using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Infrastructure.Implementations;
using IntelSyncStarter.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var settings = config.GetSection("AppSettings").Get<AppSettings>();

var services = new ServiceCollection();
services.Configure<AppSettings>(config.GetSection("AppSettings"));
services.AddTransient<DataSeeder>();
services.AddTransient<BatchSyncProcessor>();
services.AddScoped<ISyncJobs, SyncJobs>();
services.AddScoped<ISyncJobsRepository, SyncJobsRepository>();
services.AddScoped<IUser, User>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<ISyncValidator<CrmUser>, SimpleTokenValidator>();

var provider = services.BuildServiceProvider();

var seeder = provider.GetRequiredService<DataSeeder>();
await seeder.SeedAsync();

IBatchSyncProcessor process = provider.GetRequiredService<BatchSyncProcessor>();
await process.ProcessSyncJobsAsync();