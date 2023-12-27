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
    public class DeliveryStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Enums.Delivery_Status Status { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [Required]
        public int LastUpdatedBy { get; set; } //user id
        public virtual Package Package { get; set; }
        public virtual Rider Rider { get; set; }
    }
}
