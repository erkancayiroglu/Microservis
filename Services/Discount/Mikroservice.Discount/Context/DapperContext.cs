using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mikroservis.Discount.Entites;
using System.Data;

namespace Mikroservis.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-378S14D\\SQLEXPRESS;initial Catalog=MicroservisDiscountDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }

}
