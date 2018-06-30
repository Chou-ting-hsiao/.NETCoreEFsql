using CoreEF.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace CoreEF
{
    class Program
    {

        static void Main(string[] args)
        {
          
            var db = new SchoolContext();
            //get the table with relation table
            var a=db.Student.Include(x=>x.Class).ToList();
            var a=db.Student.Include(x=>x.Class2).ToList();


            Console.Read();
        }
    }
}
