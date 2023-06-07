using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Struct_Record_net
{
    public record Record
    {
        public int age { get; set; }
        public int id { get; set; }
        public Record(int age, int id)
        {
            this.age = age;
            this.id = id;
        }

    }
}
