using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingApp.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string SourceLocation { get; set; }
        public string CurrentLocation { get; set; }
        public string Destination { get; set; }
        public DateTime ETA { get; set; }
    }
}
