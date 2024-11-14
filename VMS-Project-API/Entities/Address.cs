using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS_Project_API.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? PinCode { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public int WardId { get; set; }
        public Ward? Ward { get; set; }
        public int ZoneId { get; set; }
        public Zone? Zone { get; set; }
        public int AreaId { get; set; }
        public Area? Area { get; set; }
        public decimal? Latitute { get; set; }
        public decimal? Longitute { get; set; }
        public string? Remark { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;

    }
}
