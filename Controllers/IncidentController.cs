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
        private readonly DataService _context;

        public IncidentController(DataService context)
        {
            _context = context;
        }

        [HttpGet("GetIncidents")]
        public IEnumerable<Incident> GetIncidents()
        {
            return _context.Get(new Incident());
        }

        [HttpGet("GetAccounts")]
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Get(new Account());
        }

        [HttpGet("GetContacts")]
        public IEnumerable<Contact> GetContacts()
        {
            return _context.Get(new Contact());
        }

        [HttpPost("AddIncident")]
        public IActionResult Add(Incident incident)
        {
            _context.Add(incident);
            _context.Save();
            return Ok();
        }

        [HttpPost("AddAccount")]
        public IActionResult Add(Account item)
        {
            _context.Add(item);
            _context.Save();
            return Ok();
        }

        [HttpPost("AddContact")]
        public IActionResult Add(Contact item)
        {
            _context.Add(item);
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
            _context.Edit(item);
            _context.Save();
            return Ok();
        }
        [HttpPut("DeleteAccount")]
        public IActionResult Delete(Account item)
        {
            _context.Edit(item);
            _context.Save();
            return Ok();
        }
        [HttpPut("DeleteContact")]
        public IActionResult Delete(Contact item)
        {
            _context.Edit(item);
            _context.Save();
            return Ok();
        }
    }
}
