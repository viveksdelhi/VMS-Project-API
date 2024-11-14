using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.EntitiesDTO.Update
{
    public class UpdateCameraTrackingDataDTO
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public string? VehicleImage { get; set; }
        public string? NoPlateImage { get; set; }
        public string? VehicleNo { get; set; }
        public char AlertType { get; set; }
        public bool Status { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}
