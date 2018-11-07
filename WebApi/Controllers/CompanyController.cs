using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using DataLayer.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        Context db = new Context();

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            ObservableCollection<Company> CompanyList = new ObservableCollection<Company>();
            using (db)
            {
                var query = from c in db.Companies select c;
                foreach (var c in query)
                {
                    CompanyList.Add(c);
                }

                return CompanyList;
            }

        }

        // GET: api/Company/5
        public IHttpActionResult Get(int id)
        {
            var query = from c in db.Companies select c;
            var Company = query.FirstOrDefault(c => c.Id == id);
            if (Company == null)
            {
                return NotFound();
            }
            return Ok(Company);
        }

        // POST: api/Company
        public Company Post([FromBody]Company value)
        {
            using (db)
            {
                db.Companies.Add(value);
                db.SaveChanges();
            }

            var message = Request.CreateResponse(HttpStatusCode.Created, value);
            return value;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody] Company newValues)
        {
            using (db)
            {
                var companyToUpdate = db.Companies.Find(id);
                if (companyToUpdate != null)
                {
                   companyToUpdate.Name = newValues.Name;
                   companyToUpdate.Street = newValues.Street;
                   companyToUpdate.City = newValues.City;
                   companyToUpdate.State = newValues.State;
                   companyToUpdate.Zip = newValues.Zip;
                    db.SaveChanges();
                }
            }
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
