using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreEF.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CourseID { get; set; }

        public int Course2ID { get; set; }



        //[ForeignKey("ClassID")]
        public Course Course { get; set; }

        public Course2 Course2 { get; set; }


    }
}
