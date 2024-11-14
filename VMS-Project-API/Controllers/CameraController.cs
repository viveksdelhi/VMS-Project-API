﻿using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using VMS_Project_API.Data;
using VMS_Project_API.Entities;
using VMS_Project_API.EntitiesDTO;
using VMS_Project_API.EntitiesDTO.Create;
using VMS_Project_API.EntitiesDTO.Read;
using VMS_Project_API.EntitiesDTO.Update;

namespace VMS_Project_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CameraController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CameraDTO> cameraDTOs)
        {
            if (cameraDTOs == null || !cameraDTOs.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var cameras = cameraDTOs.Select(dto => new Camera
                {

                    //Name = dto.Name,
                    //CameraIP = dto.CameraIP,
                    //Area = dto.Area,
                    //Location = dto.Location,
                    //Zone = dto.Zone,
                    //NVRId = dto.NVRId,
                    //GroupId = dto.GroupId,
                    //Brand = dto.Brand,
                    //Manufacture = dto.Manufacture,
                    //MacAddress = dto.MacAddress,
                    //Make = dto.Make,
                    //Model = dto.Model,
                    //Unit = dto.Unit,
                    //Standard = dto.Standard,
                    //Profile = dto.Profile,
                    //Protocol = dto.Protocol,
                    //Port = dto.Port,
                    //ChannelId = dto.ChannelId,
                    //Latitude = dto.Latitude,
                    //Longitude = dto.Longitude,
                    //InstallationDate = dto.InstallationDate,
                    //RTSPURL = dto.RTSPURL,
                    //PinCode = dto.PinCode,
                    //Status = dto.Status
                }).ToList();

                _context.tbl_Camera.AddRange(cameras);
                await _context.SaveChangesAsync();
                return Ok("Data imported successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while importing data: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("export-json")]
        public async Task<IActionResult> ExportJsonData()
        {
            try
            {
                var cameras = await _context.tbl_Camera.ToListAsync();
                return Ok(cameras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while exporting data: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportData()
        {
            try
            {
                var cameras = await _context.tbl_Camera.ToListAsync();

                using var writer = new StringWriter();
                using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));
                csv.WriteRecords(cameras);
                var csvContent = writer.ToString();

                return File(Encoding.UTF8.GetBytes(csvContent), "text/csv", "cameras.csv");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while exporting data: {ex.Message}");
            }
        }


        [AllowAnonymous]
        [HttpGet("Get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //var ucp = await _context.tbl_Camera.Include(i => i.NVR).OrderByDescending(x => x.Id).ToListAsync();
                //var ucp = await _context.tbl_Camera.Include(i => i.Group).Include(i => i.NVR).OrderByDescending(x => x.Id).ToListAsync();
                //return Ok(ucp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Count")]
        public async Task<IActionResult> GetCountStats()
        {
            try
            {
                var totalCameras = await _context.tbl_Camera.CountAsync();
                var activeCameras = await _context.tbl_Camera.CountAsync(c => c.Status == true);
                var inActiveCameras = await _context.tbl_Camera.CountAsync(c => c.Status == false);

                var result = new
                {
                    TotalCamera = totalCameras,
                    ActiveCamera = activeCameras,
                    InActiveCamera = inActiveCameras
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




        [AllowAnonymous]
        [HttpGet("Pagination")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.tbl_Camera.OrderByDescending(x => x.Id).AsQueryable();

                var pagedCameras = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalCount = await query.CountAsync();

                var result = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Cameras = pagedCameras
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetByCamera")]
        public async Task<IActionResult> GetByCamera()
        {
            try
            {
                var cameras = await _context.tbl_Camera.OrderByDescending(x => x.Id)
             .Where(c => c.Status)
             .Select(c => new MultCameraDTO
             {
                 Id = c.Id,
                 //Name = c.Name,
                 //RTSPURL = c.RTSPURL,
                 //Latitude = c.Latitude,
                 //Longitude = c.Longitude
             })
             .ToListAsync();

                return Ok(cameras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cmr = await _context.tbl_Camera.OrderByDescending(x => x.Id).FirstOrDefaultAsync(u => u.Id == id);
                if (cmr == null)
                {
                    return NotFound();
                }
                return Ok(cmr);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] CameraDTO cameraDTO)
        {
            try
            {
                if (cameraDTO == null)
                {
                    return BadRequest("Invalid data.");
                }

                var cmr = new Camera
                {
                    //Name = cameraDTO.Name,
                    CameraIP = cameraDTO.CameraIP,
                    //Area = cameraDTO.Area,
                    //Location = cameraDTO.Location,
                    //Zone = cameraDTO.Zone,
                    //NVRId = cameraDTO.NVRId,
                    //GroupId = cameraDTO.GroupId,
                    //Brand = cameraDTO.Brand,
                    //Manufacture = cameraDTO.Manufacture,
                    //MacAddress = cameraDTO.MacAddress,
                    //Make = cameraDTO.Make,
                    //Model = cameraDTO.Model,
                    //Unit = cameraDTO.Unit,
                    //Standard = cameraDTO.Standard,
                    //Profile = cameraDTO.Profile,
                    //Protocol = cameraDTO.Protocol,
                    //Port = cameraDTO.Port,
                    //ChannelId = cameraDTO.ChannelId,
                    //Latitude = cameraDTO.Latitude,
                    //Longitude = cameraDTO.Longitude,
                    //InstallationDate = cameraDTO.InstallationDate,
                    //RTSPURL = cameraDTO.RTSPURL,
                    //PinCode = cameraDTO.PinCode,
                    Status = cameraDTO.Status
                };

                await _context.tbl_Camera.AddAsync(cmr);
                await _context.SaveChangesAsync();
                return Ok(cmr);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while saving changes: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateCamera([FromBody] CameraUpdateDTO cameraDTO)
        {
            if (cameraDTO == null || cameraDTO.Id <= 0)
            {
                return BadRequest("Invalid camera data.");
            }

            try
            {
                var existingCamera = await _context.tbl_Camera.FindAsync(cameraDTO.Id);
                if (existingCamera == null)
                {
                    return NotFound($"Camera with Id {cameraDTO.Id} not found.");
                }

                //existingCamera.Name = cameraDTO.Name ?? existingCamera.Name;
                existingCamera.CameraIP = cameraDTO.CameraIP ?? existingCamera.CameraIP;
                //existingCamera.Area = cameraDTO.Area ?? existingCamera.Area;
                //existingCamera.Location = cameraDTO.Location ?? existingCamera.Location;
                //existingCamera.Zone = cameraDTO.Zone ?? existingCamera.Zone;
                //if (cameraDTO.NVRId.HasValue) existingCamera.NVRId = cameraDTO.NVRId.Value;
                //if (cameraDTO.GroupId.HasValue) existingCamera.GroupId = cameraDTO.GroupId.Value;
                //existingCamera.Brand = cameraDTO.Brand ?? existingCamera.Brand;
                //existingCamera.Manufacture = cameraDTO.Manufacture ?? existingCamera.Manufacture;
                //existingCamera.MacAddress = cameraDTO.MacAddress ?? existingCamera.MacAddress;
                //existingCamera.Make = cameraDTO.Make ?? existingCamera.Make;
                //existingCamera.Model = cameraDTO.Model ?? existingCamera.Model;
                //existingCamera.Unit = cameraDTO.Unit ?? existingCamera.Unit;
                //existingCamera.Standard = cameraDTO.Standard ?? existingCamera.Standard;
                //existingCamera.Profile = cameraDTO.Profile ?? existingCamera.Profile;
                //existingCamera.Protocol = cameraDTO.Protocol ?? existingCamera.Protocol;
                //if (cameraDTO.Port.HasValue) existingCamera.Port = cameraDTO.Port.Value;
                //if (cameraDTO.ChannelId.HasValue) existingCamera.ChannelId = cameraDTO.ChannelId.Value;
                //if (cameraDTO.Latitude.HasValue) existingCamera.Latitude = cameraDTO.Latitude.Value;
                //if (cameraDTO.Longitude.HasValue) existingCamera.Longitude = cameraDTO.Longitude.Value;
                //if (cameraDTO.InstallationDate.HasValue) existingCamera.InstallationDate = cameraDTO.InstallationDate.Value;
                //existingCamera.RTSPURL = cameraDTO.RTSPURL ?? existingCamera.RTSPURL;
                //if (cameraDTO.PinCode.HasValue) existingCamera.PinCode = cameraDTO.PinCode.Value;
                if (cameraDTO.Status.HasValue) existingCamera.Status = cameraDTO.Status.Value;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, $"An error occurred while updating the camera: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDTO cameraDTO)
        {
            if (cameraDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var user = await _context.tbl_Camera.FindAsync(cameraDTO.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Status = cameraDTO.Status;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while updating status: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cma = await _context.tbl_Camera.FirstOrDefaultAsync(x => x.Id == id);
                if (cma == null)
                {
                    return NotFound();
                }
                _context.tbl_Camera.Remove(cma);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while deleting camera: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
