using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloiathNationalBank.Models
{
    public class CachedTransaction
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public bool IsUpToDate { get; set; }   // Propiedad para identificar si los datos están actualizados o no
    }
}
