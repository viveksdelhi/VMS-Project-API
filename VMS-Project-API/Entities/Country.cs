﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}