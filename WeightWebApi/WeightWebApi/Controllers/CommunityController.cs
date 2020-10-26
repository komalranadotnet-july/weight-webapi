using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeightWebApi.Models;

namespace WeightWebApi.Controllers
{
    public class CommunityController : ApiController
    {

        private readonly ApplicationDbContext _context;
        public CommunityController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetValue()
        {
            var value = _context.Communities.ToList();
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }


        public IHttpActionResult GetValue(int id)
        {
            var value = _context.Communities.SingleOrDefault(c => c.id == id);
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }





      
        [HttpPost]
        public IHttpActionResult CreateData(Community community)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model data is invalid");
            }

            _context.Communities.Add(community);
            _context.SaveChanges();
            return Ok(community);
        }


        [HttpPut]
        public IHttpActionResult UpdateCommunity(int id, Community community)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var communityInDb = _context.Communities.SingleOrDefault(c => c.id == id);
            if (communityInDb == null)
                return NotFound();

            communityInDb.comment = community.comment;
            communityInDb.commenter = community.commenter;
           

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
            var commentInDb = _context.Communities.SingleOrDefault(c => c.id == id);
            if (commentInDb == null)
            {
                return NotFound();
            }

            _context.Communities.Remove(commentInDb);
            _context.SaveChanges();
            return Ok();
        }
  }
}
