using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.User;

namespace Biding.Application.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUser();

        Task<UserDTO> GetUserByID(int userId);

        Task<bool> RegisterUser(RegisterDTO user);
        Task<bool> LoginUser(LoginDTO user);

        Task<UserDTO> UpdateUser(int userId, UserDTO user);

        Task<ResetPasswordDTO> UpdatePassword(int userId, ResetPasswordDTO password);

        void DeleteUser(int userId);
    }
}
