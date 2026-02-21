using Project.ConcreteProduct;
using Project.Creator;
using Project.Product;

namespace Project.ConcreteCreator
{
    public class PushNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification() => new PushNotification();

        protected override void ConfigureOrderNotification(INotification notification, string recipient, string orderNumber)
        {
            if (notification is PushNotification push)
            {
                push.DeviceToken = recipient;
                push.Title = "Pedido Confirmado";
                push.Message = $"Pedido {orderNumber} confirmado!";
                push.Badge = 1;
            }
        }

        protected override void ConfigurePaymentNotification(INotification notification, string recipient, decimal amount)
        {
            if (notification is PushNotification push)
            {
                push.DeviceToken = recipient;
                push.Title = "Pagamento Pendente";
                push.Message = $"Pagamento do {amount:N2} pendente!";
                push.Badge = 1;
            }
        }

        protected override void ConfigureShippingNotification(INotification notification, string recipient, string trackingCode)
        {
            if (notification is PushNotification push)
            {
                push.DeviceToken = recipient;
                push.Title = "Pedido Enviado";
                push.Message = $"Rastreamento: {trackingCode}";
                push.Badge = 1;
            }
        }
    }
}