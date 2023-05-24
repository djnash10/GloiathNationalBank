using GloiathNationalBank.Data;
using GloiathNationalBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GloiathNationalBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly GloiathNationalBankContext _context;
        public RateController(GloiathNationalBankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Rate>> GetAllRate()
        {
            return await _context.Rates.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var rate = await _context.Rates.FirstOrDefaultAsync(r => r.Id == id);

            if (rate == null) return NotFound();

            return Ok(rate);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Rate rate)
        {
            await _context.Rates.AddAsync(rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", rate.Id, rate);
        }


        [HttpPut]
        public async Task<IActionResult> Put(Rate rate)
        {
            _context.Rates.Update(rate);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Rate rate)
        {
            if (rate == null) return NotFound();

            _context.Rates.Remove(rate);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}
    

