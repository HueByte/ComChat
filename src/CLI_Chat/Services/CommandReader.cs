using System;
using System.Threading.Tasks;
using CLI_Chat.Extensions;
using Microsoft.Extensions.Logging;

namespace CLI_Chat.Services
{
    public class commandreader : IInjectableService
    {
        private readonly ILogger _logger;
        public event Func<string, Task> InputReceived;

        public commandreader(ILogger<commandreader> logger)
        {
            _logger = logger;
        }

        public async Task Initialize() 
        {
            while(true)
            {
                var input = Console.ReadLine();
                //TODO

                await OnCommand(input);
            }
        }

        protected virtual async Task OnCommand(string input)
        {
            InputReceived?.Invoke(input);
        }
    }
}