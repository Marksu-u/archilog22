using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchiLibrary.Models;

namespace Archilogtest.Models
{
    public class CarsModelTest : BaseModel
    {
        [StringLength(50)]
        [Required()]
        public string? Name { get; set; }
        public int Price { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public BrandModelTest? Brand { get; set; }
    }
}
