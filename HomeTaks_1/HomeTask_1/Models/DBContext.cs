using HomeTask_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeTask_1
{
    public class UserDBContext: DbContext
    {
        public UserDBContext(string connectionString) 
        {
            Database.Connection.ConnectionString = connectionString;   
        }

        public DbSet<User> Users {get; set; }

    }
}