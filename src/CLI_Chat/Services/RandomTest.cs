using System;
using System.Threading.Tasks;
using CLI_Chat.Extensions;
using Microsoft.Extensions.Logging;

namespace CLI_Chat.Services
{
    public class RandomTest : IInjectableService
    {
        private readonly ILogger<RandomTest> _logger;

        public RandomTest(ILogger<RandomTest> logger)
        {
            _logger = logger;
        }

        public async void StartRandom() 
        {
            var rnd = new Random();

            _logger.LogInformation("Starting random");
            while(true)
            {
                _logger.LogInformation(rnd.Next(0, 100).ToString());
                await Task.Delay(4000);
            }
        }
    }
}