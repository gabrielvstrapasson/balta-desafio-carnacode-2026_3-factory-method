using DesignPatternChallenge;
using Project.ConcreteCreator;
using Project.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Notificações ===\n");

            NotificationCreator smsCreator = new SmsNotificationCreator();
            NotificationCreator emailCreator = new EmailNotificationCreator();
            NotificationCreator pushCreator = new PushNotificationCreator();
            NotificationCreator whatsappCreator = new WhatsAppNotificationCreator();

            smsCreator.SendOrderConfirmation("+5511999999999", "12346", "sms");
            emailCreator.SendOrderConfirmation("cliente@email.com", "12345", "email");
            pushCreator.SendShippingUpdate("device-token-abc123", "BR123456789", "push");
            whatsappCreator.SendPaymentReminder("+5511888888888", 150.00m, "whatsapp");
        }
    }
}