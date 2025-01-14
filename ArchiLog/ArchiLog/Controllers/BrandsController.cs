﻿using ArchiLibrary.controllers;
using ArchiLog.Data;
using ArchiLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchiLog.Controllers
{
    
    // [Route("api/v1/[controller]")]

    public class BrandsController : BaseController<ArchiLogDbContext, Brand, BrandsController>
    {
        public BrandsController(ArchiLogDbContext context, ILogger<BrandsController> logger) :base(context, logger)
        {
        }

    }
}
