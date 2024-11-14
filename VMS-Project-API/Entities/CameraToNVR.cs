using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.Entities
{
    public class CameraToNVR
    {
        [Key]
        public int Id { get; set; }
        public string? Camera { get; set; }
        public int NVRId { get; set; }
        public NVR? NVR { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;

    }
}
