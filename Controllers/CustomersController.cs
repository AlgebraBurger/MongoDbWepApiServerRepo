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

        public async Task<List<Customer>> Get()
        {
            var result = await collection.Find(x => x._id != null).ToListAsync();
            return result;
        }
    }
}
