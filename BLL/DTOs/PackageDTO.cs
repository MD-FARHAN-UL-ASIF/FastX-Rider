using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string DestinationAddress { get; set; }
        public ShippingMethod ShippingMehtod { get; set; }
        public bool? Insurance { get; set; }
        public DateTime EntitmatedDelivery { get; set; }
        public int DiliveryManId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PymentMethod PymentMethod { get; set; }
        public bool? Retuned { get; set; }
    }
}
