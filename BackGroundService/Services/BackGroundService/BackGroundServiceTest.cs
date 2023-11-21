
namespace BackGroundService.Services.BackGroundService
{
    public class BackGroundServiceTest : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Bu holatda dastur ishga tushgandan so'ng keyin ishlaydi
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    await Task.Delay(1000);
            //    Console.WriteLine("Dastur ishga tushdi");
            //}


            // Bu holat ham dastur ishga tushgandan so'ng ishlaydi 

            PeriodicTimer? perroit = new PeriodicTimer(TimeSpan.FromSeconds(2));
            while (await perroit.WaitForNextTickAsync(stoppingToken))
            {
                await Console.Out.WriteLineAsync("Dastur ishga tushdi");
            }


        }
    }
}
