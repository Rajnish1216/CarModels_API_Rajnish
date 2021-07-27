using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarModels_API_Rajnish.Models
{
    public class CarBrand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
