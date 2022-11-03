using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiLog.Data;
using ArchiLog.Models;
using ArchiLibrary.controllers;

namespace ArchiLog.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : BaseController<ArchiLogDbContext, Car, CarsController>
    {
        public CarsController(ArchiLogDbContext context, ILogger<CarsController> logger):base(context, logger)
        {
        }
    }
}
