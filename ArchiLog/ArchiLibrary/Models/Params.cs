using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiLibrary.Models
{
    public class Params
    {
        public string? Asc { get; set; }
        public string? Desc { get; set; }
        public string? Range { get; set; }

        public string? Search { get; set; }

        public string? FilterNameFixe { get; set; }
        public int? FilterPriceFixe { get; set; }
        public DateTime? FilterDateFixe { get; set; }
        public string? FilterNameMultiple { get; set; }

        public int? FilterInferiorPrice { get; set; }
        public int? FilterSuperiorPrice { get; set; }
        public DateTime? FilterInferiorDate { get; set; }
        public DateTime? FilterSuperiorDate { get; set; }

        public string? FilterPriceMultiple { get; set; }
        public string? FilterDateMultiple { get; set; }
    }
}
