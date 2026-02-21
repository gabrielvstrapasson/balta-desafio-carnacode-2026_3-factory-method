using Project.Product;
using System;

namespace Project.Creator
{
    public abstract class NotificationCreator
    {
        public abstract INotification CreateNotification();

        public void SendOrderConfirmation(string recipient, string orderNumber, string notificationType) 
        {
            var notification = CreateNotification();
            ConfigureOrderNotification(notification, recipient, orderNumber);
            notification.Send();
        }

        public void SendShippingUpdate(string recipient, string trackingCode, string notificationType) 
        {
            var notification = CreateNotification();
            ConfigureShippingNotification(notification, recipient, trackingCode);
            notification.Send();
        }

        public void SendPaymentReminder(string recipient, decimal amount, string notificationType) 
        {
            var notification = CreateNotification();
            ConfigurePaymentNotification(notification, recipient, amount);
            notification.Send();
        }

        protected abstract void ConfigureOrderNotification(INotification notification, string recipient, string orderNumber);
        protected abstract void ConfigureShippingNotification(INotification notification, string recipient, string trackingCode);
        protected abstract void ConfigurePaymentNotification(INotification notification, string recipient, decimal amount);

    }
}
