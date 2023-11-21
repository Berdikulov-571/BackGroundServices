namespace BackGroundService.Services.HostedServices
{
    public class HostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(10000);
            Console.WriteLine("StartAsync");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(10000);
            Console.WriteLine("StopAsync");
        }
    }
}
