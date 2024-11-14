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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("import-json")]
        public async Task<IActionResult> ImportJsonData([FromBody] List<RoleCreateDTO> roleCreateDTOs)
        {
            if (roleCreateDTOs == null || !roleCreateDTOs.Any())
            {
                return BadRequest("No data provided.");
            }

            try
            {
                var roles = roleCreateDTOs.Select(dto => new Role
                {
                    Name = dto.Name,
                    Status = dto.Status
                }).ToList();

                _context.tbl_Role.AddRange(roles);
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
                var roles = await _context.tbl_Role.ToListAsync();
                return Ok(roles);
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
                var roles = await _context.tbl_Role.ToListAsync();

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true
                };

                using (var writer = new StringWriter())
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(roles);
                    var csvContent = writer.ToString();
                    var byteArray = Encoding.UTF8.GetBytes(csvContent);
                    var stream = new MemoryStream(byteArray);

                    return File(stream, "text/csv", "tbl_Role.csv");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ucp = await _context.tbl_Role.ToListAsync();
                return Ok(ucp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetCountStats()
        {
            try
            {
                var totalRole = await _context.tbl_Role.CountAsync();
                var activeRole = await _context.tbl_Role.CountAsync(c => c.Status == true);
                var inactiveRole = await _context.tbl_Role.CountAsync(c => c.Status == false);

                var result = new
                {
                    TotalRole = totalRole,
                    ActiveRole = activeRole,
                    InactiveRole = inactiveRole
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.tbl_Role.AsQueryable();

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

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rol = await _context.tbl_Role.FirstOrDefaultAsync(u => u.Id == id);
                if (rol == null)
                {
                    return NotFound();
                }
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create([FromBody] RoleCreateDTO roleCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var role = new Role
                {
                    Name = roleCreateDTO.Name,
                    Status = roleCreateDTO.Status
                };

                await _context.tbl_Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return Ok(role);
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


        private bool RoleExists(int id)
        {
            try
            {
                return _context.tbl_Role.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking role existence: {ex.Message}");
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleUpdateDTO roleUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var role = await _context.tbl_Role.FindAsync(roleUpdateDTO.Id);
                if (role == null)
                {
                    return NotFound();
                }

                role.Name = roleUpdateDTO.Name;
                role.Status = roleUpdateDTO.Status;

                _context.tbl_Role.Update(role);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!RoleExists(roleUpdateDTO.Id))
                {
                    return NotFound();
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


        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusRoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var user = await _context.tbl_Role.FindAsync(roleDTO.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Status = roleDTO.Status;
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
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _context.tbl_Role.FindAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                _context.tbl_Role.Remove(role);
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
