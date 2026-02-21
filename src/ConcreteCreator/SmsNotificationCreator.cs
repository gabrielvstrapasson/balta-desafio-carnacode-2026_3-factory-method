using Project.ConcreteProduct;
using Project.Creator;
using Project.Product;

namespace Project.ConcreteCreator
{
    public class SmsNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification() => new SmsNotification();

        protected override void ConfigureOrderNotification(INotification notification, string recipient, string orderNumber)
        {
            if (notification is SmsNotification sms)
            {
                sms.PhoneNumber = recipient;
                sms.Message = $"Pedido {orderNumber} confirmado!";
            }
        }

        protected override void ConfigurePaymentNotification(INotification notification, string recipient, decimal amount)
        {
            if (notification is SmsNotification sms)
            {
                sms.PhoneNumber = recipient;
                sms.Message = $"Pagamento pendente: R$ {amount:N2}"
            }
        }

        protected override void ConfigureShippingNotification(INotification notification, string recipient, string trackingCode)
        {
            if (notification is SmsNotification sms)
            {
                sms.PhoneNumber = recipient;
                sms.Message = $"Pedido enviado! Rastreamento: {trackingCode}";
            }
        }
    }
}
