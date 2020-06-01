using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.BLL.DTO;

namespace WebAPI.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetAsync(string id);
        public Task<List<UserDto>> GetAllAsync();
        public Task CreateAsync(CreateUserDto dto);
        public Task UpdateAsync(CreateUserDto dto,string id);
        public Task RemoveAsync(string id);
    }
}