using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class RowType
    {
        public int Id;
        public string Name;

        public RowType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
