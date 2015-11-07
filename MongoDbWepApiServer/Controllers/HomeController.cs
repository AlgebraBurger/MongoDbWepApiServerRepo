using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbWepApiServer.DAL;
using MongoDbWepApiServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDbWepApiServer.Controllers
{
    public class HomeController : Controller
    {
        public IMongoCollection<Customer> collection;
        public HomeController()
        {
            var MongoDb = new MongoConnect();
            collection = MongoDb.db.GetCollection<Customer>("Customers");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        //public async System.Threading.Tasks.Task<ActionResult> Index()
        //{
        //    ViewBag.Title = "Home Page";


        //    await collection.InsertOneAsync(new Customer
        //    {
        //        _id = ObjectId.GenerateNewId().ToString(),
               
        //        FirstName ="Julius",
        //        LastName ="Bacosa",
        //        YearlyIncome =125000,
        //        DateJoined =DateTime.Parse("2015-10-10")
        //    });

        //    await collection.InsertOneAsync(new Customer
        //    {
        //        _id = ObjectId.GenerateNewId().ToString(),
              
        //        FirstName = "Elon",
        //        LastName = "Musk",
        //        YearlyIncome = 125000,
        //        DateJoined = DateTime.Parse("2015-10-10")
        //    });

        //    await collection.InsertOneAsync(new Customer
        //    {
        //        _id = ObjectId.GenerateNewId().ToString(),                
        //        FirstName = "Bill",
        //        LastName = "Gates",
        //        YearlyIncome = 125000,
        //        DateJoined = DateTime.Parse("2015-10-10")
        //    });


        //    return View();
        //}
    }
}
