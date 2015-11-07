using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbWepApiServer.DAL
{
    public class MongoConnect
    {
        public IMongoDatabase db;
        public MongoConnect()
        {
            var client = new MongoClient();
            db = client.GetDatabase("MongoWebApiServer");            
        }
    }
}
