using FoodZone.Data.Infrastructure;
using FoodZone.Models.Common;
using FoodZone.Services.BaseServices;
using FoodZone.Services.IServices;

namespace FoodZone.Services.Services
{
    public class SalaryServidces : BaseServices<Salary>, ISalaryServices
    {
        public SalaryServidces(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
