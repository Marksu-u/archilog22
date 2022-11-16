using ArchiLibrary.Data;
using ArchiLibrary.Extensions;
using ArchiLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArchiLibrary.controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public abstract class BaseController<TContext, TModel, TController> : ControllerBase where TContext : BaseDbContext where TModel : BaseModel 
    {
        protected readonly TContext _context;
        private readonly ILogger<TController> _logger;

        public BaseController(TContext context, ILogger<TController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<List<TModel>>> GetAll(
            [FromQuery] Params param, 
            [FromQuery] ParamsPagination @params)
        {
            _logger.LogInformation("Ca passe ou ca casse");

            var items = _context.Set<TModel>().Where(x => x.Active)
                .Sort(param)
                .OrderBy(x => x.ID);

            var paginationMetadata = new PaginationMetadata(items.Count(), @params.Page, @params.ItemsPerPage) ;
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var results  = await items
                .Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage)
                .ToListAsync();

            return Ok(results);
        }



        [HttpGet("{id}")]// /api/{item}/3
        public async Task<ActionResult<TModel>> GetById([FromRoute] int id)
        {


            var item = await _context.Set<TModel>().SingleOrDefaultAsync(x => x.ID == id);
            if (item == null || !item.Active)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] TModel item)
        {
            item.Active = true;
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TModel>> PutItem([FromRoute] int id, [FromBody] TModel item)
        {
            if (id != item.ID)
                return BadRequest();
            if (!ItemExists(id))
                return NotFound();

            //_context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TModel>> DeleteItem([FromRoute] int id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);
            if (item == null)
                return BadRequest();
            //_context.Entry(item).State = EntityState.Deleted;
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Set<TModel>().Any(x => x.ID == id);
        }

        
    }
}
