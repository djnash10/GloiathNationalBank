using GloiathNationalBank.Data;
using GloiathNationalBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GloiathNationalBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly GloiathNationalBankContext _context;
        
        public TransactionController(GloiathNationalBankContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {

            return await _context.Transactions.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null) return NotFound();

            return Ok(transaction);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Transaction transaction)
        {

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", transaction.Id, transaction);
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Transactions.Update(transaction);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}
