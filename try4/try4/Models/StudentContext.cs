using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace try4.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(): base("name=firstconnection")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}