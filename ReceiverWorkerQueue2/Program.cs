using CommonMethods;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverWorkerQueue2
{
    class Program
    {
        static void Main(string[] args)
        {
            Common messagingService = new Common();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpQueueForOneWayMessageDemo(model);
            messagingService.ReceiveWorkerQueueMessages(model);
        }
    }
}
