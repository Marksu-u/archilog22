using ArchiLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archilogtest.Models
{
    public class BrandModelTest : BaseModel
    {
        [StringLength(50)]
        [Required()]
        public string? Name { get; set; }

        //[Column(Name="nomdeColonne")]
        public string? Slogan { get; set; }
    }
}
