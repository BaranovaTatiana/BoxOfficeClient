using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class RowFoodExtended
    {
        public int Id;
        public string Name;
        public double Price;
        public string Color;
        public string Type;

        public RowFoodExtended(int id, string name, string type,  string color, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            Color = color;
            Type = type;
        }
    }
}
