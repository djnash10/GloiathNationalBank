using GloiathNationalBank.Data;
using GloiathNationalBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GloiathNationalBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListAllTransactionSkuController : ControllerBase
    {
        private readonly GloiathNationalBankContext _context;

        public ListAllTransactionSkuController(GloiathNationalBankContext context)
        {
            _context = context;
        }


        [HttpGet("sku/{sku}/transactions")]
        public async Task<ActionResult<ProductSummary>> GetProductTransactions(string sku)
        {
            var transactions = await _context.Transactions
            .Where(t => t.Sku == sku)
            .ToListAsync();

            if (transactions == null || transactions.Count == 0)
            {
                return NotFound();
            }

            decimal totalAmountEUR = CalculateTotalAmountEUR(transactions);

            var productSummary = new ProductSummary
            {
                Sku = sku,
                MyProperty = totalAmountEUR
            };

            return Ok(productSummary);
        }

        private decimal CalculateTotalAmountEUR(List<Transaction> transactions)
        {
            decimal totalAmountEUR = 0;

            foreach (var transaction in transactions)
            {
                decimal rateToEUR = GetRateToEUR(transaction.Currency);

                decimal amountEUR = transaction.Amount * rateToEUR;

                totalAmountEUR += amountEUR;
            }

            return totalAmountEUR;
        }

        private decimal GetRateToEUR(string currency)
        {
            decimal rateToEUR = _context.Rates
                .Where(r => r.From == currency && r.To == "EUR")
                .Select(r => r.RateValue)
                .FirstOrDefault();

            if (rateToEUR == 0)
            {
                // Si no se encuentra una tasa de conversión directa, calcular la tasa utilizando las conversiones disponibles
                rateToEUR = CalculateIndirectRateToEUR(currency);
            }

            return rateToEUR;
        }

        private decimal CalculateIndirectRateToEUR(string currency)
        {
            decimal rateToEUR = 0;

            // Obtener las tasas de conversión disponibles
            var rates = _context.Rates.ToList();

            // Buscar una conversión indirecta utilizando las tasas disponibles
            foreach (var rate in rates)
            {
                if (rate.To == "EUR")
                {
                    decimal intermediateRate = GetRateToEUR(rate.From);

                    if (intermediateRate != 0)
                    {
                        rateToEUR = intermediateRate * rate.RateValue;
                        break;
                    }
                }
            }

            return rateToEUR;
        }

    }
}
