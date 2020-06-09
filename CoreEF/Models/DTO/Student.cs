using Newtonsoft.Json;
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

        public int CID { get; set; }

        public int C2ID { get; set; }



        [JsonIgnore]
        public Course Course { get; set; }

        [JsonIgnore]
        public Course2 Course2 { get; set; }


    }
}
