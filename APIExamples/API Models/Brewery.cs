using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.API_Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brewery_Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
        public string Phone { get; set; }
        public string Website_url { get; set; }
    }

}
