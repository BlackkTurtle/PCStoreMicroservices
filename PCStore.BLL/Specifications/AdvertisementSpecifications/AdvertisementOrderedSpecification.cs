﻿using PCStore.DAL.Specification;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.AdvertisementSpecifications
{
    public class AdvertisementOrderedSpecification : BaseSpecification<Advertisement, Advertisement>
    {
        public AdvertisementOrderedSpecification()
        {
            AddCaching("ordered-advertisements");
            ApplyOrderBy(x => x.Order);
        }
    }
}
