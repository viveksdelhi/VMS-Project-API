using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMS_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialIncludeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_Users_UserId",
                table: "ActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertMasters_Cameras_CameraId",
                table: "AlertMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_CameraActivities_Cameras_CameraId",
                table: "CameraActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_CameraActivities_Users_UserId",
                table: "CameraActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_cameraAlerts_Cameras_CameraId",
                table: "cameraAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_CameraAlertStatuss_Cameras_CameraId",
                table: "CameraAlertStatuss");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraRecord_Cameras_CameraId",
                table: "tbl_CameraRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraTrackingData_Cameras_CameraId",
                table: "tbl_CameraTrackingData");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Feature_Profiles_ProfileId",
                table: "tbl_Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_License_LicenseId",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_LicenseActivation_Users_UserId",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAndtbl_Feature_tbl_Feature_FeaturesId",
                table: "ProfileAndtbl_Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAndtbl_Feature_Profiles_ProfileId",
                table: "ProfileAndtbl_Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Camera_Permissions_Cameras_CameraId",
                table: "user_Camera_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Camera_Permissions_Users_UserId",
                table: "user_Camera_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhatsAppAlerts",
                table: "WhatsAppAlerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoAnalytics",
                table: "VideoAnalytics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Camera_Permissions",
                table: "user_Camera_Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadedVehicleNoPlates",
                table: "ReadedVehicleNoPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAndtbl_Feature",
                table: "ProfileAndtbl_Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NVR",
                table: "NVR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_multCameras",
                table: "multCameras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_License",
                table: "tbl_License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_LicenseActivation",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Group",
                table: "tbl_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Feature",
                table: "tbl_Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraTrackingData",
                table: "tbl_CameraTrackingData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_GroupId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_NVRId",
                table: "Cameras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraRecord",
                table: "tbl_CameraRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CameraIPLists",
                table: "CameraIPLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CameraAlertStatuss",
                table: "CameraAlertStatuss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cameraAlerts",
                table: "cameraAlerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CameraActivities",
                table: "CameraActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertMasters",
                table: "AlertMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityLogs",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "NVRType",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Zone",
                table: "NVR");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "LastLive",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Manufacture",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "NVRId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Protocol",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "RTSPURL",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "isRecording",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "isStreaming",
                table: "Cameras");

            migrationBuilder.RenameTable(
                name: "WhatsAppAlerts",
                newName: "tbl_WhatsAppAlert");

            migrationBuilder.RenameTable(
                name: "VideoAnalytics",
                newName: "tbl_VideoAnalytics");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tbl_User");

            migrationBuilder.RenameTable(
                name: "user_Camera_Permissions",
                newName: "tbl_UserCameraPermission");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tbl_Role");

            migrationBuilder.RenameTable(
                name: "ReadedVehicleNoPlates",
                newName: "tbl_ReadedVehicleNoPlates");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "tbl_Profile");

            migrationBuilder.RenameTable(
                name: "ProfileAndtbl_Feature",
                newName: "tbl_ProfileAndFeature");

            migrationBuilder.RenameTable(
                name: "NVR",
                newName: "tbl_NVR");

            migrationBuilder.RenameTable(
                name: "multCameras",
                newName: "tbl_MultCamera");

            migrationBuilder.RenameTable(
                name: "tbl_License",
                newName: "tbl_License");

            migrationBuilder.RenameTable(
                name: "tbl_LicenseActivation",
                newName: "tbl_LicenseActivation");

            migrationBuilder.RenameTable(
                name: "tbl_Group",
                newName: "tbl_Group");

            migrationBuilder.RenameTable(
                name: "tbl_Feature",
                newName: "tbl_Feature");

            migrationBuilder.RenameTable(
                name: "tbl_CameraTrackingData",
                newName: "tbl_CameraTrackingData");

            migrationBuilder.RenameTable(
                name: "Cameras",
                newName: "tbl_Camera");

            migrationBuilder.RenameTable(
                name: "tbl_CameraRecord",
                newName: "tbl_CameraRecord");

            migrationBuilder.RenameTable(
                name: "CameraIPLists",
                newName: "tbl_CameraIPList");

            migrationBuilder.RenameTable(
                name: "CameraAlertStatuss",
                newName: "tbl_CameraAlertStatus");

            migrationBuilder.RenameTable(
                name: "cameraAlerts",
                newName: "tbl_cameraAlert");

            migrationBuilder.RenameTable(
                name: "CameraActivities",
                newName: "tbl_CameraActivitie");

            migrationBuilder.RenameTable(
                name: "AlertMasters",
                newName: "tbl_AlertMaster");

            migrationBuilder.RenameTable(
                name: "ActivityLogs",
                newName: "tbl_ActivityLog");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "tbl_User",
                newName: "IX_tbl_User_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "tbl_User",
                newName: "IX_tbl_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MobileNo",
                table: "tbl_User",
                newName: "IX_tbl_User_MobileNo");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EmailId",
                table: "tbl_User",
                newName: "IX_tbl_User_EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Camera_Permissions_UserId",
                table: "tbl_UserCameraPermission",
                newName: "IX_tbl_UserCameraPermission_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Camera_Permissions_CameraId",
                table: "tbl_UserCameraPermission",
                newName: "IX_tbl_UserCameraPermission_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "tbl_Role",
                newName: "IX_tbl_Role_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileAndtbl_Feature_ProfileId",
                table: "tbl_ProfileAndFeature",
                newName: "IX_tbl_ProfileAndFeature_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileAndtbl_Feature_FeaturesId",
                table: "tbl_ProfileAndFeature",
                newName: "IX_tbl_ProfileAndFeature_FeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_LicenseActivation_UserId",
                table: "tbl_LicenseActivation",
                newName: "IX_tbl_LicenseActivation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_LicenseActivation_LicenseId",
                table: "tbl_LicenseActivation",
                newName: "IX_tbl_LicenseActivation_LicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Feature_ProfileId",
                table: "tbl_Feature",
                newName: "IX_tbl_Feature_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraTrackingData_CameraId",
                table: "tbl_CameraTrackingData",
                newName: "IX_tbl_CameraTrackingData_CameraId");

            migrationBuilder.RenameColumn(
                name: "Zone",
                table: "tbl_Camera",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "tbl_Camera",
                newName: "Password");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraRecord_CameraId",
                table: "tbl_CameraRecord",
                newName: "IX_tbl_CameraRecord_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_CameraIPLists_CameraIP",
                table: "tbl_CameraIPList",
                newName: "IX_tbl_CameraIPList_CameraIP");

            migrationBuilder.RenameIndex(
                name: "IX_CameraAlertStatuss_CameraId",
                table: "tbl_CameraAlertStatus",
                newName: "IX_tbl_CameraAlertStatus_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_cameraAlerts_CameraId",
                table: "tbl_cameraAlert",
                newName: "IX_tbl_cameraAlert_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_CameraActivities_UserId",
                table: "tbl_CameraActivitie",
                newName: "IX_tbl_CameraActivitie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CameraActivities_CameraId",
                table: "tbl_CameraActivitie",
                newName: "IX_tbl_CameraActivitie_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertMasters_CameraId",
                table: "tbl_AlertMaster",
                newName: "IX_tbl_AlertMaster_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLogs_UserId",
                table: "tbl_ActivityLog",
                newName: "IX_tbl_ActivityLog_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_WhatsAppAlert",
                table: "tbl_WhatsAppAlert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_VideoAnalytics",
                table: "tbl_VideoAnalytics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_User",
                table: "tbl_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_UserCameraPermission",
                table: "tbl_UserCameraPermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Role",
                table: "tbl_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ReadedVehicleNoPlates",
                table: "tbl_ReadedVehicleNoPlates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Profile",
                table: "tbl_Profile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ProfileAndFeature",
                table: "tbl_ProfileAndFeature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_NVR",
                table: "tbl_NVR",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_MultCamera",
                table: "tbl_MultCamera",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_License",
                table: "tbl_License",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_LicenseActivation",
                table: "tbl_LicenseActivation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Group",
                table: "tbl_Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Feature",
                table: "tbl_Feature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraTrackingData",
                table: "tbl_CameraTrackingData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Camera",
                table: "tbl_Camera",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraRecord",
                table: "tbl_CameraRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraIPList",
                table: "tbl_CameraIPList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraAlertStatus",
                table: "tbl_CameraAlertStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_cameraAlert",
                table: "tbl_cameraAlert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraActivitie",
                table: "tbl_CameraActivitie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_AlertMaster",
                table: "tbl_AlertMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ActivityLog",
                table: "tbl_ActivityLog",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tbl_Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Country", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_State_tbl_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tbl_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_City_tbl_State_StateId",
                        column: x => x.StateId,
                        principalTable: "tbl_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Area_tbl_City_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Ward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Ward_tbl_City_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Zone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Zone_tbl_City_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PinCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Latitute = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Longitute = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "tbl_Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_City_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tbl_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_State_StateId",
                        column: x => x.StateId,
                        principalTable: "tbl_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "tbl_Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Address_tbl_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tbl_Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_AreaId",
                table: "tbl_Address",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_CityId",
                table: "tbl_Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_CountryId",
                table: "tbl_Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_StateId",
                table: "tbl_Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_WardId",
                table: "tbl_Address",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Address_ZoneId",
                table: "tbl_Address",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Area_CityId",
                table: "tbl_Area",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_City_StateId",
                table: "tbl_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_State_CountryId",
                table: "tbl_State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Ward_CityId",
                table: "tbl_Ward",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Zone_CityId",
                table: "tbl_Zone",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ActivityLog_tbl_User_UserId",
                table: "tbl_ActivityLog",
                column: "UserId",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_AlertMaster_tbl_Camera_CameraId",
                table: "tbl_AlertMaster",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraActivitie_tbl_Camera_CameraId",
                table: "tbl_CameraActivitie",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraActivitie_tbl_User_UserId",
                table: "tbl_CameraActivitie",
                column: "UserId",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_cameraAlert_tbl_Camera_CameraId",
                table: "tbl_cameraAlert",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraAlertStatus_tbl_Camera_CameraId",
                table: "tbl_CameraAlertStatus",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraRecord_tbl_Camera_CameraId",
                table: "tbl_CameraRecord",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraTrackingData_tbl_Camera_CameraId",
                table: "tbl_CameraTrackingData",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Feature_tbl_Profile_ProfileId",
                table: "tbl_Feature",
                column: "ProfileId",
                principalTable: "tbl_Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_License_LicenseId",
                table: "tbl_LicenseActivation",
                column: "LicenseId",
                principalTable: "tbl_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_User_UserId",
                table: "tbl_LicenseActivation",
                column: "UserId",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ProfileAndFeature_tbl_Feature_FeaturesId",
                table: "tbl_ProfileAndFeature",
                column: "FeaturesId",
                principalTable: "tbl_Feature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ProfileAndFeature_tbl_Profile_ProfileId",
                table: "tbl_ProfileAndFeature",
                column: "ProfileId",
                principalTable: "tbl_Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_User_tbl_Role_RoleId",
                table: "tbl_User",
                column: "RoleId",
                principalTable: "tbl_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_UserCameraPermission_tbl_Camera_CameraId",
                table: "tbl_UserCameraPermission",
                column: "CameraId",
                principalTable: "tbl_Camera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_UserCameraPermission_tbl_User_UserId",
                table: "tbl_UserCameraPermission",
                column: "UserId",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ActivityLog_tbl_User_UserId",
                table: "tbl_ActivityLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_AlertMaster_tbl_Camera_CameraId",
                table: "tbl_AlertMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraActivitie_tbl_Camera_CameraId",
                table: "tbl_CameraActivitie");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraActivitie_tbl_User_UserId",
                table: "tbl_CameraActivitie");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_cameraAlert_tbl_Camera_CameraId",
                table: "tbl_cameraAlert");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraAlertStatus_tbl_Camera_CameraId",
                table: "tbl_CameraAlertStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraRecord_tbl_Camera_CameraId",
                table: "tbl_CameraRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CameraTrackingData_tbl_Camera_CameraId",
                table: "tbl_CameraTrackingData");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Feature_tbl_Profile_ProfileId",
                table: "tbl_Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_License_LicenseId",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_User_UserId",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ProfileAndFeature_tbl_Feature_FeaturesId",
                table: "tbl_ProfileAndFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ProfileAndFeature_tbl_Profile_ProfileId",
                table: "tbl_ProfileAndFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_User_tbl_Role_RoleId",
                table: "tbl_User");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_UserCameraPermission_tbl_Camera_CameraId",
                table: "tbl_UserCameraPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_UserCameraPermission_tbl_User_UserId",
                table: "tbl_UserCameraPermission");

            migrationBuilder.DropTable(
                name: "tbl_Address");

            migrationBuilder.DropTable(
                name: "tbl_Area");

            migrationBuilder.DropTable(
                name: "tbl_Ward");

            migrationBuilder.DropTable(
                name: "tbl_Zone");

            migrationBuilder.DropTable(
                name: "tbl_City");

            migrationBuilder.DropTable(
                name: "tbl_State");

            migrationBuilder.DropTable(
                name: "tbl_Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_WhatsAppAlert",
                table: "tbl_WhatsAppAlert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_VideoAnalytics",
                table: "tbl_VideoAnalytics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_UserCameraPermission",
                table: "tbl_UserCameraPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_User",
                table: "tbl_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Role",
                table: "tbl_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ReadedVehicleNoPlates",
                table: "tbl_ReadedVehicleNoPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ProfileAndFeature",
                table: "tbl_ProfileAndFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Profile",
                table: "tbl_Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_NVR",
                table: "tbl_NVR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_MultCamera",
                table: "tbl_MultCamera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_LicenseActivation",
                table: "tbl_LicenseActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_License",
                table: "tbl_License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Group",
                table: "tbl_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Feature",
                table: "tbl_Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraTrackingData",
                table: "tbl_CameraTrackingData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraRecord",
                table: "tbl_CameraRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraIPList",
                table: "tbl_CameraIPList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraAlertStatus",
                table: "tbl_CameraAlertStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_cameraAlert",
                table: "tbl_cameraAlert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CameraActivitie",
                table: "tbl_CameraActivitie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Camera",
                table: "tbl_Camera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_AlertMaster",
                table: "tbl_AlertMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ActivityLog",
                table: "tbl_ActivityLog");

            migrationBuilder.RenameTable(
                name: "tbl_WhatsAppAlert",
                newName: "WhatsAppAlerts");

            migrationBuilder.RenameTable(
                name: "tbl_VideoAnalytics",
                newName: "VideoAnalytics");

            migrationBuilder.RenameTable(
                name: "tbl_UserCameraPermission",
                newName: "user_Camera_Permissions");

            migrationBuilder.RenameTable(
                name: "tbl_User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tbl_Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tbl_ReadedVehicleNoPlates",
                newName: "ReadedVehicleNoPlates");

            migrationBuilder.RenameTable(
                name: "tbl_ProfileAndFeature",
                newName: "ProfileAndtbl_Feature");

            migrationBuilder.RenameTable(
                name: "tbl_Profile",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "tbl_NVR",
                newName: "NVR");

            migrationBuilder.RenameTable(
                name: "tbl_MultCamera",
                newName: "multCameras");

            migrationBuilder.RenameTable(
                name: "tbl_LicenseActivation",
                newName: "tbl_LicenseActivation");

            migrationBuilder.RenameTable(
                name: "tbl_License",
                newName: "tbl_License");

            migrationBuilder.RenameTable(
                name: "tbl_Group",
                newName: "tbl_Group");

            migrationBuilder.RenameTable(
                name: "tbl_Feature",
                newName: "tbl_Feature");

            migrationBuilder.RenameTable(
                name: "tbl_CameraTrackingData",
                newName: "tbl_CameraTrackingData");

            migrationBuilder.RenameTable(
                name: "tbl_CameraRecord",
                newName: "tbl_CameraRecord");

            migrationBuilder.RenameTable(
                name: "tbl_CameraIPList",
                newName: "CameraIPLists");

            migrationBuilder.RenameTable(
                name: "tbl_CameraAlertStatus",
                newName: "CameraAlertStatuss");

            migrationBuilder.RenameTable(
                name: "tbl_cameraAlert",
                newName: "cameraAlerts");

            migrationBuilder.RenameTable(
                name: "tbl_CameraActivitie",
                newName: "CameraActivities");

            migrationBuilder.RenameTable(
                name: "tbl_Camera",
                newName: "Cameras");

            migrationBuilder.RenameTable(
                name: "tbl_AlertMaster",
                newName: "AlertMasters");

            migrationBuilder.RenameTable(
                name: "tbl_ActivityLog",
                newName: "ActivityLogs");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_UserCameraPermission_UserId",
                table: "user_Camera_Permissions",
                newName: "IX_user_Camera_Permissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_UserCameraPermission_CameraId",
                table: "user_Camera_Permissions",
                newName: "IX_user_Camera_Permissions_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_User_Username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_User_MobileNo",
                table: "Users",
                newName: "IX_Users_MobileNo");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_User_EmailId",
                table: "Users",
                newName: "IX_Users_EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Role_Name",
                table: "Roles",
                newName: "IX_Roles_Name");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ProfileAndFeature_ProfileId",
                table: "ProfileAndtbl_Feature",
                newName: "IX_ProfileAndtbl_Feature_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ProfileAndFeature_FeaturesId",
                table: "ProfileAndtbl_Feature",
                newName: "IX_ProfileAndtbl_Feature_FeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_LicenseActivation_UserId",
                table: "tbl_LicenseActivation",
                newName: "IX_tbl_LicenseActivation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_LicenseActivation_LicenseId",
                table: "tbl_LicenseActivation",
                newName: "IX_tbl_LicenseActivation_LicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Feature_ProfileId",
                table: "tbl_Feature",
                newName: "IX_tbl_Feature_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraTrackingData_CameraId",
                table: "tbl_CameraTrackingData",
                newName: "IX_tbl_CameraTrackingData_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraRecord_CameraId",
                table: "tbl_CameraRecord",
                newName: "IX_tbl_CameraRecord_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraIPList_CameraIP",
                table: "CameraIPLists",
                newName: "IX_CameraIPLists_CameraIP");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraAlertStatus_CameraId",
                table: "CameraAlertStatuss",
                newName: "IX_CameraAlertStatuss_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_cameraAlert_CameraId",
                table: "cameraAlerts",
                newName: "IX_cameraAlerts_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraActivitie_UserId",
                table: "CameraActivities",
                newName: "IX_CameraActivities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CameraActivitie_CameraId",
                table: "CameraActivities",
                newName: "IX_CameraActivities_CameraId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Cameras",
                newName: "Zone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Cameras",
                newName: "Unit");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_AlertMaster_CameraId",
                table: "AlertMasters",
                newName: "IX_AlertMasters_CameraId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ActivityLog_UserId",
                table: "ActivityLogs",
                newName: "IX_ActivityLogs_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NVRType",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "NVR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Zone",
                table: "NVR",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "Cameras",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLive",
                table: "Cameras",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Cameras",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Cameras",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Manufacture",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NVRId",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PinCode",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Protocol",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RTSPURL",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "Cameras",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Cameras",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRecording",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isStreaming",
                table: "Cameras",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhatsAppAlerts",
                table: "WhatsAppAlerts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoAnalytics",
                table: "VideoAnalytics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Camera_Permissions",
                table: "user_Camera_Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadedVehicleNoPlates",
                table: "ReadedVehicleNoPlates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAndtbl_Feature",
                table: "ProfileAndtbl_Feature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NVR",
                table: "NVR",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_multCameras",
                table: "multCameras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_LicenseActivation",
                table: "tbl_LicenseActivation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_License",
                table: "tbl_License",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Group",
                table: "tbl_Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Feature",
                table: "tbl_Feature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraTrackingData",
                table: "tbl_CameraTrackingData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CameraRecord",
                table: "tbl_CameraRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CameraIPLists",
                table: "CameraIPLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CameraAlertStatuss",
                table: "CameraAlertStatuss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cameraAlerts",
                table: "cameraAlerts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CameraActivities",
                table: "CameraActivities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertMasters",
                table: "AlertMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityLogs",
                table: "ActivityLogs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_GroupId",
                table: "Cameras",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_NVRId",
                table: "Cameras",
                column: "NVRId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Users_UserId",
                table: "ActivityLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertMasters_Cameras_CameraId",
                table: "AlertMasters",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CameraActivities_Cameras_CameraId",
                table: "CameraActivities",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CameraActivities_Users_UserId",
                table: "CameraActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cameraAlerts_Cameras_CameraId",
                table: "cameraAlerts",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CameraAlertStatuss_Cameras_CameraId",
                table: "CameraAlertStatuss",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraRecord_Cameras_CameraId",
                table: "tbl_CameraRecord",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_tbl_Group_GroupId",
                table: "Cameras",
                column: "GroupId",
                principalTable: "tbl_Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_NVR_NVRId",
                table: "Cameras",
                column: "NVRId",
                principalTable: "NVR",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CameraTrackingData_Cameras_CameraId",
                table: "tbl_CameraTrackingData",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Feature_Profiles_ProfileId",
                table: "tbl_Feature",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_LicenseActivation_tbl_License_LicenseId",
                table: "tbl_LicenseActivation",
                column: "LicenseId",
                principalTable: "tbl_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_LicenseActivation_Users_UserId",
                table: "tbl_LicenseActivation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAndtbl_Feature_tbl_Feature_FeaturesId",
                table: "ProfileAndtbl_Feature",
                column: "FeaturesId",
                principalTable: "tbl_Feature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAndtbl_Feature_Profiles_ProfileId",
                table: "ProfileAndtbl_Feature",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Camera_Permissions_Cameras_CameraId",
                table: "user_Camera_Permissions",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Camera_Permissions_Users_UserId",
                table: "user_Camera_Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
