using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using RabbitMQ.Client;

namespace SenderPublisSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Common messagingService = new Common();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpQueueForWorkerQueueDemo(model);
            RunPublishSubscribeMessageDemo(model, messagingService);
        }
        private static void RunPublishSubscribeMessageDemo(IModel model, Common messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "q") break;

                messagingService.SendMessageToPublishSubscribeQueues(message, model);
            }
        }
    }
}
