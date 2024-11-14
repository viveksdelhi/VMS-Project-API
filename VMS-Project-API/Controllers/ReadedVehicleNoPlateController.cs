using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using VMS_Project_API.Data;
using VMS_Project_API.Entities;
using VMS_Project_API.EntitiesDTO.Create;
using VMS_Project_API.EntitiesDTO.Update;

namespace VMS_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadedVehicleNoPlateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReadedVehicleNoPlateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CreateVehicleDetectionDTO> activityLogDTOs)
        {
            if (activityLogDTOs == null || !activityLogDTOs.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var activityLog = activityLogDTOs.Select(dto => new ReadedVehicleNoPlate
                {
                    FramePath = dto.FramePath,
                    PlatePath = dto.PlatePath,
                    Text = dto.Text
                }).ToList();

                _context.tbl_ReadedVehicleNoPlates.AddRange(activityLog);
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
                var activityLog = await _context.tbl_ReadedVehicleNoPlates.ToListAsync();
                return Ok(activityLog);
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
                var tbl_ReadedVehicleNoPlates = await _context.tbl_ReadedVehicleNoPlates.ToListAsync();

                using var writer = new StringWriter();
                using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));
                csv.WriteRecords(tbl_ReadedVehicleNoPlates);
                var csvContent = writer.ToString();

                return File(Encoding.UTF8.GetBytes(csvContent), "text/csv", "ReadedVehicleNoPlate.csv");
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
                var ucp = await _context.tbl_ReadedVehicleNoPlates.ToListAsync();
                return Ok(ucp);
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
                var totalActivityLog = await _context.tbl_ReadedVehicleNoPlates.CountAsync();

                var result = new
                {
                    TotalDetection = totalActivityLog,
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
                var query = _context.tbl_ReadedVehicleNoPlates.AsQueryable();

                var pagedRoles = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalCount = await query.CountAsync();

                var result = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Roles = pagedRoles
                };

                return Ok(result);
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
                var cmrs = await _context.tbl_ReadedVehicleNoPlates.FirstOrDefaultAsync(u => u.Id == id);
                if (cmrs == null)
                {
                    return NotFound();
                }
                return Ok(cmrs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create(CreateVehicleDetectionDTO activityLogDto)
        {
            try
            {
                var activityLog = new ReadedVehicleNoPlate
                {
                    FramePath = activityLogDto.FramePath,
                    PlatePath = activityLogDto.PlatePath,
                    Text = activityLogDto.Text
                };

                await _context.tbl_ReadedVehicleNoPlates.AddAsync(activityLog);
                await _context.SaveChangesAsync();

                return Ok(activityLog);
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


        private bool CMRSExists(int id)
        {
            try
            {
                return _context.tbl_ReadedVehicleNoPlates.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking role existence: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateCMRS([FromBody] CreateVehicleDetectionDTO updateDto)
        {
            try
            {
                if (updateDto.Id < 1)
                {
                    return BadRequest("Invalid ID.");
                }

                var existingActivityLog = await _context.tbl_ReadedVehicleNoPlates.FindAsync(updateDto.Id);
                if (existingActivityLog == null)
                {
                    return NotFound("Activity Log not found.");
                }

                if (updateDto.FramePath != null)
                    existingActivityLog.FramePath = updateDto.FramePath;

                if (updateDto.PlatePath != null)
                    existingActivityLog.PlatePath = updateDto.PlatePath;

                if (updateDto.Text != null)
                    existingActivityLog.Text = updateDto.Text;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CMRSExists(updateDto.Id))
                {
                    return NotFound("Activity Log not found.");
                }
                else
                {
                    throw new Exception($"An error occurred while updating role: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCMRS(int id)
        {
            try
            {
                var cmrs = await _context.tbl_ReadedVehicleNoPlates.FindAsync(id);
                if (cmrs == null)
                {
                    return NotFound();
                }

                _context.tbl_ReadedVehicleNoPlates.Remove(cmrs);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while deleting role: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
