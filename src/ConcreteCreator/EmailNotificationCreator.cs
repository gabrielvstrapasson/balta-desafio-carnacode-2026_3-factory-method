using Project.ConcreteProduct;
using Project.Creator;
using Project.Product;

namespace Project.ConcreteCreator
{
    public class EmailNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification() => new EmailNotification();

        protected override void ConfigureOrderNotification(INotification notification, string recipient, string orderNumber)
        {
            if (notification is EmailNotification email)
            {
                email.Recipient = recipient;
                email.Subject = "Confirmação de Pedido";
                email.Body = $"Seu pedido {orderNumber} foi confirmado!";
                email.IsHtml = true;
            }
        }

        protected override void ConfigurePaymentNotification(INotification notification, string recipient, decimal amount)
        {
            if (notification is EmailNotification email)
            {
                email.Recipient = recipient;
                email.Subject = "Lembrete de Pagamento";
                email.Body = $"Você tem um pagamento pendente de R$ {amount:N2}";
                email.IsHtml = true;
            }
        }

        protected override void ConfigureShippingNotification(INotification notification, string recipient, string trackingCode)
        {
            if (notification is EmailNotification email)
            {
                email.Recipient = recipient;
                email.Subject = "Pedido Enviado";
                email.Body = $"Seu pedido foi enviado! Código de rastreamento: {trackingCode}";
                email.IsHtml = true;
            }
        }
    }
}
