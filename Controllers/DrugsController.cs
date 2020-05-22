using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using APBD11.Models;
using APBD11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD11.Controllers
{
    [Route("api/drugs")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IDrugsDb _context;
        public DrugsController(IDrugsDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            return Ok(_context.AddDoctor(doctor));
        }
        [HttpPut]
        public IActionResult ModifyDoctor(Doctor doc)
        {
            return Ok(_context.ModifyDoctor(doc));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _context.DeleteDoctor(id);
            return Ok();
        }

        [HttpPost("/seed")]
        public IActionResult Seed()
        {
            _context.Seed();
            return Ok();
        }
    }
}