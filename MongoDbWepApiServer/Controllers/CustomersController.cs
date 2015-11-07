using MongoDB.Bson;
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
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MongoDbWepApiServer.Controllers
{
    [EnableCors(origins: "http://localhost:57184", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {

        public IMongoCollection<Customer> collection;
        public CustomersController()
        {
            var MongoDb = new MongoConnect();            
            collection = MongoDb.db.GetCollection<Customer>("Customers");
        }
        // GET api/customers
        public async Task<List<Customer>> GetCustomers()
        {
            var result = await collection.Find(x => x._id != null).ToListAsync();
            return result;
        }

        // GET api/customers/5
        public async Task<List<Customer>> GetCustomer(string id)
        {
            var result = await collection.Find(Builders<Customer>.Filter.Eq("_id", id)).ToListAsync();
            return result;
        }

        // POST: api/Customers        
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            await collection.InsertOneAsync(new Customer
            {
                _id = ObjectId.GenerateNewId().ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                YearlyIncome = customer.YearlyIncome,
                DateJoined = customer.DateJoined
            });

            return CreatedAtRoute("DefaultApi", new { id = customer._id }, customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(string id, Customer customer)
        {
            await collection.UpdateManyAsync(Builders<Customer>.Filter.Eq("_id", id), Builders<Customer>.Update.Set("FirstName", customer.FirstName));
            await collection.UpdateManyAsync(Builders<Customer>.Filter.Eq("_id", id), Builders<Customer>.Update.Set("LastName", customer.LastName));
            await collection.UpdateManyAsync(Builders<Customer>.Filter.Eq("_id", id), Builders<Customer>.Update.Set("YearlyIncome", customer.YearlyIncome));
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Customers/5
        public async Task<DeleteResult> DeleteCustomer(string id)
        {   
            var result = await collection.DeleteOneAsync(Builders<Customer>.Filter.Eq("_id", id));
            return result;
        }


    
    }
}
