using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.BLL.DTO;
using WebAPI.BLL.Exceptions;
using WebAPI.BLL.Extensions;
using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Entities;
using WebAPI.DAL.Interfaces;

namespace WebAPI.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public async Task<UserDto> GetAsync(string id)
        {
            User user = await _unitOfWork.UserManager.FindByIdAsync(id);
            if(user == null)
                throw new ValidationException("user not found");

            return user.ToBllUserDetail();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await _unitOfWork.UserManager.Users.ToListAsync();
            return list.ToBllUsersDetail();
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            await _unitOfWork.UserManager.CreateAsync(dto.ToDal());
        }

        public async Task UpdateAsync(CreateUserDto dto,string id)
        {
            User user = await _unitOfWork.UserManager.FindByIdAsync(id);
            if(user == null)
                throw new ValidationException("user not found");

            user.Email = dto.Email;
            user.UserName = dto.UserName;
            await _unitOfWork.UserManager.UpdateAsync(user);
        }

        public async Task RemoveAsync(string id) 
        {
            User user = await _unitOfWork.UserManager.FindByIdAsync(id);
            if(user == null)
                throw new ValidationException("user not found");

            await _unitOfWork.UserManager.DeleteAsync(user);
        }
    }
}