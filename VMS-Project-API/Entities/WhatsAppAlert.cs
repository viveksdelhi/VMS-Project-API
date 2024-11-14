using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.Entities
{
    public class WhatsAppAlert
    {
        [Key]
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string Message { get; set; }
        public string MobileNo { get; set; }
        public char AlertType { get; set; }
        public string DeviceType { get; set; }
        public DateTime RegDate { get; set; }= DateTime.Now;
    }
}
