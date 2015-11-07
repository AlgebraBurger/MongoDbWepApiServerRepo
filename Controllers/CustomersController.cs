using MongoDB.Driver;
using MongoDbWepApiServer.DAL;
using MongoDbWepApiServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MongoDbWepApiServer.Controllers
{
    public class CustomersController : ApiController
    {

        public IMongoCollection<Customer> collection;
        public CustomersController()
        {
            var MongoDb = new MongoConnect();            
            collection = MongoDb.db.GetCollection<Customer>("Customers");
        }
        // GET api/customers
        public async Task<List<Customer>> Get()
        {
            var result = await collection.Find(x => x._id != null).ToListAsync();
            return result;
        }

        // GET api/customers/5
        public async Task<List<Customer>> Get(string id)
        {
            var result = await collection.Find(Builders<Customer>.Filter.Eq("_id", id)).ToListAsync();
            return result;
        }

        public void Delegate()
        {
            //collection.DeleteManyAsync(x => x.FullName == "Anakinxxx");
        }
    }
}
