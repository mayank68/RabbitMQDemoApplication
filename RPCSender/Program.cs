using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
namespace RPCSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Common messagingService = new Common();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpQueueForRpcDemo(model);
            RunRpcMessageDemo(model, messagingService);
        }
        private static void RunRpcMessageDemo(IModel model, Common messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "q") break;
                String response = messagingService.SendRpcMessageToQueue(message, model, TimeSpan.FromMinutes(1));
                Console.WriteLine("Response: {0}", response);
            }
        }
    }
}
