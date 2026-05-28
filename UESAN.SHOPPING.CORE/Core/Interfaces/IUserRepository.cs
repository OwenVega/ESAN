using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> SignupIn(User user);
        Task<User> SingIn(string email, string contra);
    }
}