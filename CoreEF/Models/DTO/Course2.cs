using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEF.Models
{
    public class Course2
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[InverseProperty("Class")]
        public List<Student> Students { get; set; }
    }
}
