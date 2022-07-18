using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class NewsServices : BaseServices<News>, INewsServices
    {
        public NewsServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
