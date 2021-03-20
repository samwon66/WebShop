using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Database
{
    public class WSContext : DbContext
    {
        private const string DatabaseName = "WebbShopSammyWong";

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Book> Books { get; set; }
        //public DbSet<SoldBook> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"Server = .\SQLEXPRESS;Database={DatabaseName};trusted_connection=true;");
        }
    }
}
