﻿namespace ProductAPI.Data
{
    using ProductAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions opt) : base(opt)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
