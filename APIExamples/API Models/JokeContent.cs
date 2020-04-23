using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.API_Models
{
    public class JokeContent
    {
        public int Id { get; set; }
        public string Joke { get; set; }
        public string[] Categories { get; set; }
    }
}
