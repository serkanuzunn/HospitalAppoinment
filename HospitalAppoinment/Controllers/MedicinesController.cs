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
    public class MedicinesController:ControllerBase
    {
        private readonly HospitalContext _context;

        public MedicinesController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMedicines()
        {
            var medicines = _context.Medicines.ToList();
            return Ok(medicines);
        }

        [HttpPost]
        public IActionResult AddMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return Ok(medicine);
        }
    }
}
