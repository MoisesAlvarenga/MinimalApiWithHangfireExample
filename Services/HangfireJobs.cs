namespace MinimalApi.Services;

public static class HangfireJobs
{
    public static async Task FireAndForgetJob()
    {
        await Task.Run(() => {
            Console.WriteLine("Fire And Forget job");
        });
    }

    public static async Task RecurringJob()
    {
        await Task.Run(() => {
            Console.WriteLine("Recurring Job");
        });
    }

    public static async Task ScheduleJob()
    {
         await Task.Run(() => {
            Console.WriteLine("Delayed Job");
        });
    }

    public static async Task  FatherJob()
    {
        await Task.Run(() => {
            Console.WriteLine("Father Job");
        });
    }

        public static async Task SonJob()
    {
        await Task.Run(() => {
            Console.WriteLine("Son Job");
        });
    }

}