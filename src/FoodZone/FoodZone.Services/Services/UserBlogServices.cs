﻿using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class UserBlogServices : BaseServices<UserBlog>, IUserBlogServices
    {
        public UserBlogServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}