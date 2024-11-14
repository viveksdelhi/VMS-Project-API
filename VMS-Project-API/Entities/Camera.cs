using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace VMS_Project_API.Entities
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }
        public string? CameraIP { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;

        //public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? CameraIP { get; set; }
        //public string? Username { get; set; }
        //public string? Password { get; set; }


        //public string? Area { get; set; }
        //public string? Location { get; set; }
        //public string? Zone { get; set; }
        //public NVR? NVR { get; set; }
        //public int? NVRId { get; set; }
        //public Group? Group { get; set; }
        //public int? GroupId { get; set; }
        //public string? Brand { get; set; }
        //public string? Manufacture { get; set; }
        //public string? MacAddress { get; set; }
        //public string? Make { get; set; }
        //public string? Model { get; set; }
        //public string? Unit { get; set; }
        //public string? Standard { get; set; }
        //public string? Profile { get; set; }
        //public string? Protocol { get; set; }
        //public int? Port { get; set; }
        //public int? ChannelId { get; set; }
        //public decimal? Latitude { get; set; }
        //public decimal? Longitude { get; set; }
        //public DateTime? InstallationDate { get; set; }
        //public DateTime? LastLive { get; set; }
        //public string? RTSPURL { get; set; }
        //public int? PinCode { get; set; }
        //public bool? isRecording { get; set; } = false;
        //public bool? isStreaming { get; set; } = false;
        //public bool Status { get; set; } = true;
        //public DateTime? UpdateDate { get; set; }
        //public DateTime RegDate { get; set; } = DateTime.Now;
    }
}
