using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biding.Application.DTOs.User;

namespace Biding.Application.User
{
    public class UserService : IUserService
    {
        private readonly BidingDbContext BidingDbContext;

        public UserService(BidingDbContext bidingDbContext)
        {
            this.BidingDbContext = bidingDbContext;
        }

        async Task<IEnumerable<UserDTO>> GetUser()
        {
            var Users = (from User in this.BidingDbContext.Users
                         select new UserDTO
                         {
                             UserName = User.UserName,
                             Email = User.Email,
                             Password = User.Password,
                             Role = User.Role
                         }).ToListAsync();
            return await Users;
        }

        async Task<UserDTO> GetUserByID(int userId)
        {
            var User = this.BidingDbContext.Users.Find(userId);
            if (User != null)
            {
                var userDTO = new UserDTO
                {
                    UserName = User.UserName,
                    Email = User.Email,
                    Password = User.Password,
                    Role = User.Role
                };
                return userDTO;
            }
            return null!;
        }

        public async Task<bool> RegisterUser(RegisterDTO user)
        {
            if (BidingDbContext.Users.AnyAsync(u => u.Email == user.Email))
                return false;
            var userDTO = new RegisterDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            BidingDbContext.Users.Add(userDTO);
            await BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        async Task<bool> LoginUser(LoginDTO user)
        {
            var User =BidingDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email );
              
            await this.BidingDbContext.SaveChangesAsync();
            return OK(true);
        }

        Task<UserDTO> UpdateUser(int userId, UserDTO user)
        {
            var User = this.BidingDbContext.Users.Find(userId);
            if (User != null)
            {
                User.UpdateUser(user.UserName, user.Email, user.Password, User.Role);
                this.BidingDbContext.SaveChangesAsync();
            }
            return null!;
        }

        Task<ResetPasswordDTO> UpdatePassword(int userId, ResetPasswordDTO password)
        {
            var User = this.BidingDbContext.Users.Find(userId);
            if (User != null)
            {
                User.UpdatePassword(password.Password);
                this.BidingDbContext.SaveChangesAsync();
            }
            return null!;
        }

        void DeleteUser(int userId)
        {
            var User = this.BidingDbContext.Users.Find(userId);
            if (User != null)
            {
                this.BidingDbContext.Users.Remove(User);
                this.BidingDbContext.SaveChangesAsync();
            }
        }
    }
}
