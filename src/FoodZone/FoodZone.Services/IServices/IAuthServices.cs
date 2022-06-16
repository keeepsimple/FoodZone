using FoodZone.Services.DTO;

namespace FoodZone.Services.IServices
{
    public interface IAuthServices
    {
        Task<string> CreateToken();

        Task<bool> ValidateUser(LoginUserDTO loginUser);
    }
}
