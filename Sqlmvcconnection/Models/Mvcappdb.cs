using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sqlmvcconnection.Models
{
    public class Mvcappdb : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}