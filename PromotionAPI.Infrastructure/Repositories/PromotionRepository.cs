using PromotionAPI.ApplicationCore.Contracts.Repositories;
using PromotionAPI.ApplicationCore.Entities;
using PromotionAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAPI.Infrastructure.Repositories
{
    public class PromotionRepository : BaseRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(PromotionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
