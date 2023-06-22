using HospitalAppoinment.Data;
using HospitalAppoinment.Models;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace HospitalAppoinment.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientsController:ControllerBase
    {
        private readonly HospitalContext _context;

        public PatientsController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return Ok(patient);
        }
    }
}
