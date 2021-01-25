using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CLI_Chat.Services
{
    public class CommandReader
    {
        private readonly ILogger _logger;
        public event EventHandler CommandHandler;

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

                OnCommand(EventArgs.Empty);
            }
        }

        protected virtual void OnCommand(EventArgs e)
        {
            CommandHandler?.Invoke(this, e);
        }
    }
}