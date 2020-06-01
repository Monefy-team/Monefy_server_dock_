using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.BLL.DTO;
using WebAPI.DAL.Entities;


namespace WebAPI.BLL.Interfaces
{
    public interface IFinanceService
    {
        Task<FinanceDto> GetAsync(int id);
        Task<List<FinanceDto>> GetAllAsync();
        Task CreateAsync(CreateFinanceDto dto);
        Task RemoveAsync(int id);
        Task UpdateAsync(EditFinanceDto dto,int id);
    }
}