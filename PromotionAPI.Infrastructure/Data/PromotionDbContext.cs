using Microsoft.EntityFrameworkCore;
using PromotionAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAPI.Infrastructure.Data
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions<PromotionDbContext> option):base(option)
        {
            
        }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetails> PromotionDetails { get; set; }
    }
}
