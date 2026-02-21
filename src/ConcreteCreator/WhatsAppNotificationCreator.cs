using Project.ConcreteProduct;
using Project.Creator;
using Project.Product;

namespace Project.ConcreteCreator
{
    public class WhatsAppNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification() => new WhatsAppNotification();

        protected override void ConfigureOrderNotification(INotification notification, string recipient, string orderNumber)
        {
            if (notification is WhatsAppNotification whatsapp)
            {
                whatsapp.PhoneNumber = recipient;
                whatsapp.Message = $"✅ Seu pedido {orderNumber} foi confirmado!";
                whatsapp.UseTemplate = true;
            }
        }

        protected override void ConfigurePaymentNotification(INotification notification, string recipient, decimal amount)
        {
            if (notification is WhatsAppNotification whatsapp)
            {
                whatsapp.PhoneNumber = recipient;
                whatsapp.Message = $"📦 Você tem um pagamento pendente: {amount:N2}";
                whatsapp.UseTemplate = true;
            }
        }

        protected override void ConfigureShippingNotification(INotification notification, string recipient, string trackingCode)
        {
            if (notification is WhatsAppNotification whatsapp)
            {
                whatsapp.PhoneNumber = recipient;
                whatsapp.Message = $"📦 Pedido enviado! Rastreamento: {trackingCode}";
                whatsapp.UseTemplate = true;
            }
        }
    }
}
