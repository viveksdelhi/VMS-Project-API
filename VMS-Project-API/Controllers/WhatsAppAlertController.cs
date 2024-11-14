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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppAlertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WhatsAppAlertController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CreateWhatsAppAlertDTO> createWhatsAppAlerts)
        {
            if (createWhatsAppAlerts == null || !createWhatsAppAlerts.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var whatsApps = createWhatsAppAlerts.Select(dto => new WhatsAppAlert
                {
                    DeviceId = dto.DeviceId,
                    Message = dto.Message,
                    MobileNo = dto.MobileNo,
                    AlertType = dto.AlertType,
                    DeviceType = dto.DeviceType
                }).ToList();

                _context.tbl_WhatsAppAlert.AddRange(whatsApps);
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
                var whatsApps = await _context.tbl_WhatsAppAlert.ToListAsync();
                return Ok(whatsApps);
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
                var whatsapps = await _context.tbl_WhatsAppAlert.ToListAsync();

                using var writer = new StringWriter();
                using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));
                csv.WriteRecords(whatsapps);
                var csvContent = writer.ToString();

                return File(Encoding.UTF8.GetBytes(csvContent), "text/csv", "WhatsAppAlert.csv");
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
                var whatsapp = await _context.tbl_WhatsAppAlert.ToListAsync();
                return Ok(whatsapp);
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
                var whatsapps = await _context.tbl_WhatsAppAlert.CountAsync();

                var result = new
                {
                    TotalWhatsAppAlert = whatsapps
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
                var whatsapp = _context.tbl_WhatsAppAlert.AsQueryable();

                var pagedRoles = await whatsapp
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalCount = await whatsapp.CountAsync();

                var result = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
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
                var whatsApp = await _context.tbl_WhatsAppAlert.FirstOrDefaultAsync(u => u.Id == id);
                if (whatsApp == null)
                {
                    return NotFound();
                }
                return Ok(whatsApp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create(CreateWhatsAppAlertDTO whatsAppAlertDTO)
        {
            try
            {
                var whatsApp = new WhatsAppAlert
                {
                    DeviceId = whatsAppAlertDTO.DeviceId,
                    Message = whatsAppAlertDTO.Message,
                    MobileNo = whatsAppAlertDTO.MobileNo,
                    AlertType = whatsAppAlertDTO.AlertType,
                    DeviceType = whatsAppAlertDTO.DeviceType

                };

                await _context.tbl_WhatsAppAlert.AddAsync(whatsApp);
                await _context.SaveChangesAsync();

                return Ok(whatsApp);
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
                return _context.tbl_WhatsAppAlert.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking role existence: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateCMRS([FromBody] UpdateWhatsAppAlertDTO updateDto)
        {
            try
            {
                if (updateDto.Id < 1)
                {
                    return BadRequest("Invalid ID.");
                }

                var existingActivityLog = await _context.tbl_WhatsAppAlert.FindAsync(updateDto.Id);
                if (existingActivityLog == null)
                {
                    return NotFound("Activity Log not found.");
                }

                if (updateDto.DeviceId != null)
                    existingActivityLog.DeviceId = updateDto.DeviceId;

                if (updateDto.Message != null)
                    existingActivityLog.Message = updateDto.Message;

                if (updateDto.MobileNo != null)
                    existingActivityLog.MobileNo = updateDto.MobileNo;

                if (updateDto.AlertType != null)
                    existingActivityLog.AlertType = updateDto.AlertType;

                if (updateDto.DeviceType != null)
                    existingActivityLog.DeviceType = updateDto.DeviceType;

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
                var whatsApp = await _context.tbl_WhatsAppAlert.FindAsync(id);
                if (whatsApp == null)
                {
                    return NotFound();
                }

                _context.tbl_WhatsAppAlert.Remove(whatsApp);
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
