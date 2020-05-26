using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreEF.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[InverseProperty("Class")]
        public List<Student> Students { get; set; }
    }
}
