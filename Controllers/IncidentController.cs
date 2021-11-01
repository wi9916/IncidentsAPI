using IncidentsAPI.Interfaces;
using IncidentsAPI.Models;
using IncidentsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {        
        private readonly IIncidentService _context;

        public IncidentController(IIncidentService context)
        {
            _context = context;
        }

        [HttpPost("AddIncident")]
        public IActionResult Add(Incident item)
        {
            if (!_context.AddIncident(item))          
                return NotFound();
           
            _context.Save();
            return Ok();
        }

        [HttpPost("AddAccount")]
        public IActionResult Add(Account item)
        {
            if (!_context.AddAccount(item))
                return BadRequest();
           
            _context.Save();
            return Ok();
        }

        [HttpPost("AddContact")]
        public IActionResult Add(Contact item)
        {
            if (!_context.AddContact(item))
                return BadRequest();

            _context.Save();
            return Ok();
        }

        [HttpPut("EdditIncident")]
        public IActionResult Eddit(Incident item)
        {
            _context.Edit(item);
            _context.Save();
            return Ok();
        }

        [HttpPut("EdditAccount")]
        public IActionResult Eddit(Account item)
        {
            _context.Edit(item);
            _context.Save();
            return Ok();
        }

        [HttpPut("EdditContact")]
        public IActionResult Eddit(Contact item)
        {
            _context.Edit(item);
            _context.Save();
            return Ok();
        }

        [HttpPut("DeleteIncident")]
        public IActionResult Delete(Incident item)
        {
            _context.Delete(item,item.IncidentName);
            return Ok();
        }
        [HttpPut("DeleteAccount")]
        public IActionResult Delete(Account item)
        {
            _context.Delete(item, item.Name);
            return Ok();
        }
        [HttpPut("DeleteContact")]
        public IActionResult Delete(Contact item)
        {
            _context.Delete(item, item.Email);
            return Ok();
        }
    }
}
