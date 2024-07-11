﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAPI.ApplicationCore.Entities
{
    public class PromotionDetails
    {
        public int Id { get; set; }

        //Navigation Property
        public int PromotionId { get; set; }

        public Promotion Promotion { get; set; }

        public int ProductCategoryId { get; set; }

        [MaxLength(250)]
        public string ProductCategoryName { get; set; }

        [MaxLength(250)]
        public string ProductName { get; set; }
    }
}
