using System;
using System.Threading.Tasks;
using CLI_Chat.Extensions;
using CLI_Chat.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CLI_Chat
{
    class Program
    {
        private readonly IServiceProvider _serviceProvider;

        public Program()
        {
            var services = new ServiceCollection()
                .AddTransient<IListener, Listener>()
                .AddServicesOfT<IInjectableService>()
                .AddLogging(log => log.ClearProviders().AddConsole().AddSerilog(dispose: true));

            _serviceProvider = services.BuildServiceProvider();
        }

        private async static Task Main()
        {
            try
            {
                await new Program().StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task StartAsync()
        {
            var listener = _serviceProvider.GetRequiredService<IListener>();
            var random = _serviceProvider.GetRequiredService<RandomTest>();
            var commandReader = _serviceProvider.GetRequiredService<commandreader>();
            _serviceProvider.GetRequiredService<CommandHandler>();
            commandReader.Initialize();
            // listener.StartListen();
            // random.StartRandom();
            // Task.Run(async() => { await listener.StartListen(); });
            // Task.Run(async () => { await random.StartRandom(); });


            await Task.Delay(-1);

        }
    }
}
