using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbWepApiServer.Models
{
    public class Customer
    {
        public object _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal YearlyIncome { get; set; }
        public DateTime DateJoined { get; set; }        
    }
}
