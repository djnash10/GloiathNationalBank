using GloiathNationalBank.Data;
using GloiathNationalBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GloiathNationalBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSummaryController : ControllerBase
    {
        private readonly GloiathNationalBankContext _context;
        public ProductSummaryController(GloiathNationalBankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductSummary>> GetAll()
        {
            return await _context.ProductSummaries.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var summary = await _context.ProductSummaries.FirstOrDefaultAsync(s => s.Id == id);

            if (summary == null) return NotFound();

            return Ok(summary);
        }

        //[HttpGet("{Sku}")]
        //public async Task<IEnumerable<ProductSummary>> GetByCategorySku(int productCategorySku)
        //{
        //    return await _context.ProductSummaries.Where(p => p.Sku == productCategorySku).ToListAsync();
        //}


        [HttpPost]
        public async Task<IActionResult> Post(ProductSummary summary)
        {
            await _context.ProductSummaries.AddAsync(summary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", summary.Id, summary);
        }


        [HttpPut]
        public async Task<IActionResult> Put(ProductSummary summary)
        {
            _context.ProductSummaries.Update(summary);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(ProductSummary summary)
        {
            if (summary == null) return NotFound();

            _context.ProductSummaries.Remove(summary);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
    

