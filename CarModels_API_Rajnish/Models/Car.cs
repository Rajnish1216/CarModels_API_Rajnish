using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarModels_API_Rajnish.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CarBrandID { get; set; }
        public int CarCategoryID { get; set; }
        public CarBrand CarBrand { get; set; }
        public CarCategory CarCategory { get; set; }
    }
}
