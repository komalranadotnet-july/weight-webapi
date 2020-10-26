using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeightWebApi.Models;

namespace WeightWebApi.Controllers
{
    public class WeightController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public WeightController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetValue()
        {
            var value = _context.Weights.ToList();
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        public IHttpActionResult GetValue(int id)
        {
            var value = _context.Weights.SingleOrDefault(c => c.id == id);
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }








        [HttpPost]
        public IHttpActionResult CreateData(Weight weight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model data is invalid");
            }

            _context.Weights.Add(weight);
            _context.SaveChanges();
            return Ok(weight);
        }


        [HttpPut]
        public IHttpActionResult UpdateCommunity(int id, Weight weight)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var weightInDb = _context.Weights.SingleOrDefault(c => c.id == id);
            if (weightInDb == null)
                return NotFound();

            weightInDb.weight = weight.weight;
            weightInDb.date = weight.date;
            weightInDb.bodyfat= weight.bodyfat;



            _context.SaveChanges();
            return Ok();

        }
        //Delete /api/customerapi/1

        public IHttpActionResult DeleteData(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid value");
            }
            var weightInDb = _context.Weights.SingleOrDefault(c => c.id == id);
            if (weightInDb == null)
            {
                return NotFound();
            }

            _context.Weights.Remove(weightInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}
