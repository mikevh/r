using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using r.Models;

namespace r.Controllers
{
    public class LinkController : ApiController
    {
        private LinkContext db = new LinkContext();

        // GET api/Link
        public IQueryable<Link> GetLinks()
        {
            return db.Links;
        }

        // GET api/Link/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult GetLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        // PUT api/Link/5
        public IHttpActionResult PutLink(int id, Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != link.Id)
            {
                return BadRequest();
            }

            db.Entry(link).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Link
        [ResponseType(typeof(Link))]
        public IHttpActionResult PostLink(Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Links.Add(link);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = link.Id }, link);
        }

        // DELETE api/Link/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult DeleteLink(int id)
        {
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            db.Links.Remove(link);
            db.SaveChanges();

            return Ok(link);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkExists(int id)
        {
            return db.Links.Count(e => e.Id == id) > 0;
        }
    }
}