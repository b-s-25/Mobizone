using DomainLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>options) : base(options)
        {

        }
        public DbSet<Registration> Register { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<MasterData> masterDatas { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<UserOrders> UserOrders { get; set; }
        public DbSet<UserCheckOut> userCheckOut { get; set; }
    }
}
