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
using MVCWebApiJquerySample.Models;

namespace MVCWebApiJquerySample.Controllers
{
    public class SchoolController : ApiController
    {
        private SchoolManagementEntities db = new SchoolManagementEntities();

        // GET api/School
        public IEnumerable<SchoolDto> GetSchools()
        {
            var schools = db.Schools.Select(t=>new SchoolDto(){ Id= t.Id, Address1=t.Address1, Address2=t.Address2, Contact = t.ContactNumber, Email=t.Email, Name = t.Name});
            return schools;
        }

        // GET api/School/5
        [ResponseType(typeof(SchoolDto))]
        public IHttpActionResult GetSchool(int id)
        {
            School t = db.Schools.Find(id);
            SchoolDto school = new SchoolDto() { Id = t.Id, Address1 = t.Address1, Address2 = t.Address2, Contact = t.ContactNumber, Email = t.Email, Name = t.Name };
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT api/School/5
        public IHttpActionResult PutSchool(int id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.Id)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST api/School
        [ResponseType(typeof(School))]
        public IHttpActionResult PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schools.Add(school);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school.Id }, school);
        }

        // DELETE api/School/5
        [ResponseType(typeof(School))]
        public IHttpActionResult DeleteSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.Schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(int id)
        {
            return db.Schools.Count(e => e.Id == id) > 0;
        }
    }
}