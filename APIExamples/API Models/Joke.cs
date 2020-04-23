using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.API_Models
{
    public class Joke
    {
        public string Type { get; set; }
        public JokeContent Value { get; set; }
    }
}
