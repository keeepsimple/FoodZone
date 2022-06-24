﻿using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class BlogServices : BaseServices<Blog>, IBlogServices
    {
        public BlogServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
