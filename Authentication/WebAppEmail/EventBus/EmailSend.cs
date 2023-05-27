using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebAppEmail.DTOs;

namespace WebAppEmail.EventBus
{
    public class EmailSend
    {
        public void ConfirmEmail(RegisterDTO registerDTO)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("");
            //factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var strJson = JsonSerializer.Serialize<RegisterDTO>(registerDTO);
                channel.QueueDeclare("emailconfirmation", false, false, true);
                byte[] bytemessage = Encoding.UTF8.GetBytes("sebepsiz boş yere ayrılacaksan");
                channel.BasicPublish(exchange: "", routingKey: "emailconfirmation", body: bytemessage);
            }
        }
    }
}
