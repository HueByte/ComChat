using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CLI_Chat.Services
{
    public class Listener : IListener
    {
        private HttpListener listener;
        private HttpListenerContext _context;
        private ILogger _logger;

        public Listener(ILogger<Listener> logger)
        {
            _logger = logger;
        }

        public async void StartListen()
        { 
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:80/");

            listener.Start();
            _logger.LogInformation("Started");

            await Task.Delay(10000);

            while (true)
            {
                //listen for data
                _context = await listener.GetContextAsync();
                Console.WriteLine("called listener");

                //get datat from request
                var request = _context.Request;
                var response = _context.Response;

                //convert data to string 
                var data = request.InputStream;
                var encoding = request.ContentEncoding;
                var reader = new StreamReader(data, encoding);
                string result = await reader.ReadToEndAsync();
                Console.WriteLine(result);

                string responseString = "<html><body>xxx</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;

                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}