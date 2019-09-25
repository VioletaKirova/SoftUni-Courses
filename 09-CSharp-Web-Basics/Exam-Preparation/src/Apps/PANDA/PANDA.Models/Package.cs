namespace PANDA.Models
{
    using PANDA.Models.Enums;
    using System;

    public class Package
    {
        public Package()
        {
            this.Status = Status.Pending;
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        public Receipt Receipt { get; set; }
    }
}
