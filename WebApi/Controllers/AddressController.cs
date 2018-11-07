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
    public class AddressController : ApiController
    {
        Context db = new Context();

        // GET: api/Address/5
       public ObservableCollection<Address> Get(int id)
       {
           ObservableCollection<Address> AddressList = new ObservableCollection<Address>();
           using (db)
           {
               var query = from address in db.Addresses
                            where address.PostInfo == id
                            select address;

                   foreach (var address in query)
                   {
                       AddressList.Add(address);
                   }
                

               return AddressList;
           }
        }

        // POST: api/Address
        public Address Post([FromBody]Address addressValue)
        {
            using (db)
            {
                var client = db.Clients.Find(addressValue.PostInfo);
                if (client.AddressList == null)
                {
                    client.AddressList = new ObservableCollection<Address>();
                }
                client.AddressList.Add(addressValue);
                db.SaveChanges();
            }

            return addressValue;
        }

        // PUT: api/Address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
