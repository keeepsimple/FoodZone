using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class SalaryServices : BaseServices<Salary>, ISalaryServices
    {
        public SalaryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
