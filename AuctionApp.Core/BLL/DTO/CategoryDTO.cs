﻿using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public List<SubcategoryDTO> Subcategories { get; set; }
    }
}
