using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context;

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
        optionsBuilder.UseSqlServer("Server=ONUR\\SQLEXPRESS;initial catalog=MultiShopDiscountDb;integrated security=True;");
    }
    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
