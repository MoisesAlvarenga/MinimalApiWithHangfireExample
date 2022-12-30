using Hangfire;
using MinimalApi.Services;

namespace MinimalApi.Api;


public static class HangfireEndpoints
{
    public static void MapMinimalApiEndpoints( this WebApplication app)
    {
        app.MapPost("/HangfireApi/FireAndForgetJob", () => {
            BackgroundJob.Enqueue(() => HangfireJobs.FireAndForgetJob());
        }).WithTags("Hangfire Jobs");

        app.MapPost("/HangfireApi/RecurringJob", () => {
            RecurringJob.AddOrUpdate(() => HangfireJobs.RecurringJob(), Cron.Minutely);
        }).WithTags("Hangfire Jobs");

        app.MapPost("/HangfireApi/ScheduleJob", () => {
            BackgroundJob.Schedule(() => HangfireJobs.ScheduleJob(), TimeSpan.FromMinutes(1));
        }).WithTags("Hangfire Jobs");

        app.MapPost("/HangfireApi/ContinuationJob", () => {
            var jobId = BackgroundJob.Enqueue(() => HangfireJobs.FatherJob());
            BackgroundJob.ContinueJobWith(jobId, () =>  HangfireJobs.SonJob());
        }).WithTags("Hangfire Jobs");
    }
}
