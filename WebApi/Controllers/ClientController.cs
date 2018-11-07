using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DataLayer;
using DataLayer.Models;
using Newtonsoft.Json;


namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        Context db = new Context();

        // GET: api/Client
        public IEnumerable<Client> Get()
        {
            ObservableCollection<Client> clientList = new ObservableCollection<Client>();
            using (db)
            {
                var query = from client in db.Clients select client;
                foreach (var client in query)
                {
                    clientList.Add(client);
                }

                return clientList;
            }

        }

        public IHttpActionResult Get(int id)
        {
            var query = from c in db.Clients select c;
            var client = query.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }


        // POST: api/Client
        public Client Post([FromBody]Client value)
        {
            using (db)
            {
                db.Clients.Add(value);
                db.SaveChanges();
            }
            return value;
        }

        // PUT: api/Client/5
        public void Put([FromBody]Client value)
        {
            using (db)
            {
                db.Clients.Add(value);
                db.SaveChanges();
            }
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
