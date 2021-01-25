using System;
using System.Threading.Tasks;
using CLI_Chat.Extensions;

namespace CLI_Chat.Services
{
    public class CommandHandler : IInjectableService
    {
        public CommandHandler(commandreader commandReader)
        {
            commandReader.InputReceived += HandleCommand;
        }

        public async Task HandleCommand(string message)
        {
            if(message[0] == '/')
            {
                //command stuff
                return;
            }

            Console.WriteLine("Start server before messaging");
        }
    }   
}