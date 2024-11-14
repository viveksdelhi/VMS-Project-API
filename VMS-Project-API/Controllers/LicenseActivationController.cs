using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VMS_Project_API.Data;
using VMS_Project_API.Entities;
using VMS_Project_API.EntitiesDTO.Create;
using VMS_Project_API.EntitiesDTO.Update;
using System.Text;

namespace VMS_Project_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseActivationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LicenseActivationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CreateLicenseActivationDTO> createtbl_LicenseActivation)
        {
            if (createtbl_LicenseActivation == null || !createtbl_LicenseActivation.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var licenseActivation = createtbl_LicenseActivation.Select(dto => new LicenseActivation
                {
                    UserId = dto.UserId,
                    LicenseId = dto.LicenseId,
                    MachineIP = dto.MachineIP,
                    ExpiryDate = dto.ExpiryDate,
                    Status = dto.Status
                }).ToList();

                _context.tbl_LicenseActivation.AddRange(licenseActivation);
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
                var tbl_LicenseActivation = await _context.tbl_LicenseActivation.ToListAsync();
                return Ok(tbl_LicenseActivation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while exporting data: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("export-excel")]
        public async Task<IActionResult> Export()
        {
            try
            {
                var tbl_LicenseActivation = await _context.tbl_LicenseActivation
                    .Include(x => x.License)
                    .Include(x => x.User)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true
                };

                using (var writer = new StringWriter())
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(tbl_LicenseActivation);
                    var csvContent = writer.ToString();
                    var byteArray = Encoding.UTF8.GetBytes(csvContent);
                    var stream = new MemoryStream(byteArray);

                    return File(stream, "text/csv", "LicenseActivation.csv");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ucp = await _context.tbl_LicenseActivation.Include(x => x.License).Include(x => x.User).OrderByDescending(x => x.Id).ToListAsync();
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
                var totalLicenseActivation = await _context.tbl_LicenseActivation.CountAsync();
                var activeLicenseActivation = await _context.tbl_LicenseActivation.CountAsync(c => c.Status == true);
                var inactiveLicenseActivation = await _context.tbl_LicenseActivation.CountAsync(c => c.Status == false);

                var result = new
                {
                    TotalLicenseActivation = totalLicenseActivation,
                    ActiveLicenseActivation = activeLicenseActivation,
                    InactiveLicenseActivation = inactiveLicenseActivation
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
                var query = _context.tbl_LicenseActivation.Include(x => x.License).Include(x => x.User).OrderByDescending(x => x.Id).AsQueryable();

                var pagedtbl_License = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalCount = await query.CountAsync();

                var result = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    tbl_LicenseActivation = pagedtbl_License
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
                var las = await _context.tbl_LicenseActivation.Include(x => x.License).Include(x => x.User).OrderByDescending(x => x.Id).FirstOrDefaultAsync(u => u.Id == id);
                if (las == null)
                {
                    return NotFound();
                }
                return Ok(las);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] CreateLicenseActivationDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var licenseActivation = new LicenseActivation
                {
                    UserId = dto.UserId,
                    LicenseId = dto.LicenseId,
                    MachineIP = dto.MachineIP,
                    ExpiryDate = dto.ExpiryDate,
                    Status = dto.Status
                };

                await _context.tbl_LicenseActivation.AddAsync(licenseActivation);
                await _context.SaveChangesAsync();
                return Ok(licenseActivation);
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


        private bool LActivationExists(int id)
        {
            try
            {
                return _context.tbl_LicenseActivation.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking license activation existence: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Update([FromBody] UpdateLicenseActivationDTO dto)
        {
            if (dto == null || dto.Id < 1)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var licenseActivation = await _context.tbl_LicenseActivation.FindAsync(dto.Id);
                if (licenseActivation == null)
                {
                    return NotFound();
                }

                licenseActivation.UserId = dto.UserId;
                licenseActivation.LicenseId = dto.LicenseId;
                licenseActivation.MachineIP = dto.MachineIP;
                licenseActivation.ExpiryDate = dto.ExpiryDate;
                licenseActivation.Status = dto.Status;

                _context.tbl_LicenseActivation.Update(licenseActivation);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!LActivationExists(dto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception($"An error occurred while updating license activation: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusLicenseActivationDTO licenseActivationDTO)
        {
            if (licenseActivationDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var user = await _context.tbl_LicenseActivation.FindAsync(licenseActivationDTO.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Status = licenseActivationDTO.Status;
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
        public async Task<IActionResult> DeleteLActivation(int id)
        {
            try
            {
                var lasv = await _context.tbl_LicenseActivation.FindAsync(id);
                if (lasv == null)
                {
                    return NotFound();
                }

                _context.tbl_LicenseActivation.Remove(lasv);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while deleting license activation: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
