using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string DestinationAddress { get; set; }
        [Required]
        public ShippingMethod ShippingMehtod { get; set; }
        public bool? Insurance { get; set; }
        [Required]
        public DateTime EntitmatedDelivery { get; set; }
        [Required]
        [ForeignKey("Rider")]
        public int DiliveryManId { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public PymentMethod PymentMethod { get; set; }
        public bool? Retuned { get; set; }
        //public DeliveryStatus DeliveryStatus { get; set; }
        public virtual Rider Rider { get; set; }
    }
}
