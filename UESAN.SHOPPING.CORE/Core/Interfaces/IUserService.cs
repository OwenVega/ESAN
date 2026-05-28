using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<LoginDTO> SignIn(SignInDTO signInDTO);
        Task<int> SignUp(UserCreateDTO userCreateDTO);
    }
}