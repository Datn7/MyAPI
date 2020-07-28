﻿using System;
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
    }
}