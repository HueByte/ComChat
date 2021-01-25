using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CLI_Chat.Services
{
    public class CommandReader
    {
        private readonly ILogger _logger;
        public event EventHandler<string> CommandHandler;

        public CommandReader(ILogger<CommandReader> logger)
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
            CommandHandler?.Invoke(this, input).GetContextAsync();
        }
    }
}