using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data
{
    public class MyAPIContext : DbContext
    {
        public MyAPIContext (DbContextOptions<MyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MyAPI.Data.MyClass> MyClass { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Photo> Photos { get; set; }


    }
}
