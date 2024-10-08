﻿using Microsoft.EntityFrameworkCore;
using SimpleCRM.Models;

namespace SimpleCRM.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products {  get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
