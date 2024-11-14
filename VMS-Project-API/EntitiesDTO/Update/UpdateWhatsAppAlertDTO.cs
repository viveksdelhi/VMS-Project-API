using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.EntitiesDTO.Update
{
    public class UpdateWhatsAppAlertDTO
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string Message { get; set; }
        public string MobileNo { get; set; }
        public char AlertType { get; set; }
        public string DeviceType { get; set; }
    }
}
