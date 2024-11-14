using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VMS_Project_API.Entities;
using VMS_Project_API.EntitiesDTO.Read;
using VMS_Project_API.Model;

namespace VMS_Project_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Role> tbl_Role { get; set; }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<Group> tbl_Group { get; set; }
        public DbSet<Camera> tbl_Camera { get; set; }
        public DbSet<User_Camera_Permission> tbl_UserCameraPermission { get; set; }
        public DbSet<License> tbl_License { get; set; }
        public DbSet<LicenseActivation> tbl_LicenseActivation { get; set; }
        public DbSet<CameraActivity> tbl_CameraActivitie { get; set; }
        public DbSet<CameraTrackingData> tbl_CameraTrackingData { get; set; }
        public DbSet<CameraRecord> tbl_CameraRecord { get; set; }
        public DbSet<MultCameraDTO> tbl_MultCamera { get; set; }
        public DbSet<CameraAlertStatus> tbl_CameraAlertStatus { get; set; }
        public DbSet<NVR> tbl_NVR { get; set; }
        public DbSet<CameraAlert> tbl_cameraAlert { get; set; }
        public DbSet<AlertMaster> tbl_AlertMaster { get; set; }
        public DbSet<ActivityLog> tbl_ActivityLog { get; set; }
        public DbSet<Profile> tbl_Profile { get; set; }
        public DbSet<Features> tbl_Feature { get; set; }
        public DbSet<ProfileAndFeatures> tbl_ProfileAndFeature { get; set; }
        public DbSet<WhatsAppAlert> tbl_WhatsAppAlert { get; set; }
        public DbSet<CameraIPList> tbl_CameraIPList { get; set; }
        public DbSet<VideoAnalytics> tbl_VideoAnalytics { get; set; }
        public DbSet<ReadedVehicleNoPlate> tbl_ReadedVehicleNoPlates { get; set; }
        public DbSet<Country> tbl_Country { get; set; }
        public DbSet<State> tbl_State { get; set; }
        public DbSet<City> tbl_City { get; set; }
        public DbSet<Ward> tbl_Ward { get; set; }
        public DbSet<Zone> tbl_Zone { get; set; }
        public DbSet<Area> tbl_Area { get; set; }
        public DbSet<Address> tbl_Address { get; set; }
    }
}
