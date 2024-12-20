﻿

using Microsoft.EntityFrameworkCore;

namespace WebTeploobmenApp.Data
{
    public class TeploobmenContext : DbContext
    {
        public DbSet<InputData> DataInput { get; set; }
        public DbSet<User> Users { get; set; }

        public TeploobmenContext(DbContextOptions<TeploobmenContext> options) : base(options){ 

        } 
    }
}
