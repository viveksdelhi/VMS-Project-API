﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.Entities
{
    public class CameraRecord
    {
        [Key]
        public int Id { get; set; }
        public Camera? Camera { get; set; }
        public int CameraId { get; set; }
        public string? RecordPath { get; set; }
        public bool Status { get; set; } = true;
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}