using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CreateProfileDTO> createProfileDTOs)
        {
            if (createProfileDTOs == null || !createProfileDTOs.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var profile = createProfileDTOs.Select(dto => new Profile
                {
                    Name = dto.Name,
                    Status = dto.Status
                }).ToList();

                _context.tbl_Profile.AddRange(profile);
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
                var profile = await _context.tbl_Profile.ToListAsync();
                return Ok(profile);
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
                var tbl_Profile = await _context.tbl_Profile.OrderByDescending(x => x.Id).ToListAsync();

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true
                };

                using (var writer = new StringWriter())
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(tbl_Profile);
                    var csvContent = writer.ToString();
                    var byteArray = Encoding.UTF8.GetBytes(csvContent);
                    var stream = new MemoryStream(byteArray);

                    return File(stream, "text/csv", "Profile.csv");
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
                var profiles = await _context.tbl_Profile.OrderByDescending(x => x.Id).ToListAsync();
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Count")]
        public async Task<IActionResult> GetProfileCount()
        {
            try
            {
                var totalProfile = await _context.tbl_Profile.CountAsync();
                var result = new { Totaltbl_Profile = totalProfile };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPagedtbl_Profile(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.tbl_Profile.OrderByDescending(x => x.Id).AsQueryable();

                var pagedData = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalCount = await query.CountAsync();

                var result = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Profiles = pagedData
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
                var profiles = await _context.tbl_Profile.FindAsync(id);
                if (profiles == null)
                {
                    return NotFound();
                }
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] CreateProfileDTO profileDTO)
        {
            if (profileDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var profile = new Profile
                {
                    Name = profileDTO.Name,
                    Status = profileDTO.Status,
                    RegDate = DateTime.Now
                };

                await _context.tbl_Profile.AddAsync(profile);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = profile.Id }, profile);
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
        public async Task<IActionResult> Update([FromBody] UpdateProfileDTO profileDTO)
        {
            if (profileDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var profile = await _context.tbl_Profile.FindAsync(profileDTO.Id);
                if (profile == null)
                {
                    return NotFound();
                }

                profile.Name = profileDTO.Name;
                profile.Status = profileDTO.Status;

                _context.tbl_Profile.Update(profile);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(profileDTO.Id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusProfileDTO profileDTO)
        {
            if (profileDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var profile = await _context.tbl_Profile.FindAsync(profileDTO.Id);
                if (profile == null)
                {
                    return NotFound();
                }

                profile.Status = profileDTO.Status;
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

        [AllowAnonymous]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var profile = await _context.tbl_Profile.FindAsync(id);
                if (profile == null)
                {
                    return NotFound();
                }

                _context.tbl_Profile.Remove(profile);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while deleting profile: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpDelete("Clear")]
        public async Task<IActionResult> Clear()
        {
            try
            {
                var profiles = await _context.tbl_Profile.ToListAsync();

                if (profiles.Any())
                {
                    _context.tbl_Profile.RemoveRange(profiles);
                    await _context.SaveChangesAsync();
                    return Ok("All records have been cleared.");
                }
                else
                {
                    return NotFound("No records found to clear.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private bool ProfileExists(int id)
        {
            return _context.tbl_Profile.Any(e => e.Id == id);
        }
    }
}
