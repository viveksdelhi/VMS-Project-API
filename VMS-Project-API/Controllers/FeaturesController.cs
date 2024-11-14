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

namespace VMS_Project_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<CreateFeatureDTO> createFeatures)
        {
            if (createFeatures == null || !createFeatures.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var feature = createFeatures.Select(dto => new Features
                {
                    Name = dto.Name,
                    ProfileId = dto.ProfileId,
                    Status = dto.Status
                }).ToList();

                _context.tbl_Feature.AddRange(feature);
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
                var features = await _context.tbl_Feature.ToListAsync();
                return Ok(features);
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
                var features = await _context.tbl_Feature.Include(f => f.Profile).ToListAsync();

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ","
                };

                using (var writer = new StringWriter())
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(features);
                    var csvContent = writer.ToString();
                    var byteArray = System.Text.Encoding.UTF8.GetBytes(csvContent);
                    var stream = new MemoryStream(byteArray);

                    return File(stream, "text/csv", "Features.csv");
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
                var features = await _context.tbl_Feature.Include(f => f.Profile).OrderByDescending(f => f.Id).ToListAsync();
                return Ok(features);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Count")]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                var totalFeatures = await _context.tbl_Feature.CountAsync();
                var result = new { TotalFeatures = totalFeatures };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPagedFeatures(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.tbl_Feature.Include(f => f.Profile).OrderByDescending(f => f.Id).AsQueryable();

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
                    Features = pagedData
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
                var feature = await _context.tbl_Feature.Include(f => f.Profile).FirstOrDefaultAsync(f => f.Id == id);
                if (feature == null)
                {
                    return NotFound();
                }
                return Ok(feature);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] CreateFeatureDTO featureDTO)
        {
            if (featureDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var feature = new Features
                {
                    Name = featureDTO.Name,
                    ProfileId = featureDTO.ProfileId,
                    Status = featureDTO.Status,
                    RegDate = DateTime.Now
                };

                await _context.tbl_Feature.AddAsync(feature);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = feature.Id }, feature);
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

        private bool FeatureExists(int id)
        {
            try
            {
                return _context.tbl_Feature.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking feature existence: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Update([FromBody] UpdateFeatureDTO featureDTO)
        {
            if (featureDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var feature = await _context.tbl_Feature.FindAsync(featureDTO.Id);
                if (feature == null)
                {
                    return NotFound();
                }

                feature.Name = featureDTO.Name;
                feature.ProfileId = featureDTO.ProfileId;
                feature.Status = featureDTO.Status;

                _context.tbl_Feature.Update(feature);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(featureDTO.Id))
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
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateFeatureStatusDTO featureDTO)
        {
            if (featureDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var feature = await _context.tbl_Feature.FindAsync(featureDTO.Id);
                if (feature == null)
                {
                    return NotFound();
                }

                feature.Status = featureDTO.Status;
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
                var feature = await _context.tbl_Feature.FindAsync(id);
                if (feature == null)
                {
                    return NotFound();
                }

                _context.tbl_Feature.Remove(feature);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while deleting feature: {ex.Message}");
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
                var features = await _context.tbl_Feature.ToListAsync();

                if (features.Any())
                {
                    _context.tbl_Feature.RemoveRange(features);
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
    }
}
