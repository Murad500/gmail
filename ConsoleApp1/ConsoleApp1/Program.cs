using ConsoleApp1.Model;
using ConsoleApp1.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("");

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("emailconfirmation", false, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("emailconfirmation", false, consumer);
    consumer.Received += (sender, e) => 
    {
        var data = JsonSerializer.Deserialize<Register>(e.Body.ToString());
        //e.Body : Kuyruktaki mesajı verir.
        //Console.WriteLine(Encoding.UTF8.GetString(e.Body));
        EmailService.SendConfirmationEmail(data.Email);
    };
}
Console.Read();




