using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Repositories;
using UESAN.SHOPPING.CORE.Core.Entities;
namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<LoginDTO> SignIn(SignInDTO signInDTO)
        {
            var user = await _userRepository.SingIn(signInDTO.Email, signInDTO.Password);
            if (user == null)
            {
                return null;
            }
            return new LoginDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Type = user.Type,
                IsActive = user.IsActive
            };
        }

        public async Task<int> SignUp(UserCreateDTO userCreateDTO)
        {
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                DateOfBirth = userCreateDTO.DateOfBirth,
                Country = userCreateDTO.Country,
                Address = userCreateDTO.Address,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password,
                Type = userCreateDTO.Type,
                IsActive = true
            };
            return await _userRepository.SignupIn(user);
        }

    }
}