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
    public class DoctorsController: ControllerBase
    {
        private readonly HospitalContext _context;

        public DoctorsController(HospitalContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = _context.Doctors.ToList();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }


    }
}
