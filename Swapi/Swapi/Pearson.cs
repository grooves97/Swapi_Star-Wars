using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swapi
{
    public class Pearson
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<object> Films { get; set; }
        public List<object> Species { get; set; }
        public List<object> Vehicles { get; set; }
        public List<object> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
    }
}
