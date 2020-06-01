using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.BLL.DTO;
using WebAPI.BLL.Exceptions;
using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Entities;
using WebAPI.DAL.Interfaces;
using WebAPI.BLL.Extensions;

namespace WebAPI.BLL.Services
{
    public class FinanceService : IFinanceService
    {
        private IUnitOfWork _unitOfWork;
        
        public FinanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<FinanceDto> GetAsync(int id)
        {
            Finance finance =  await _unitOfWork.Finances.GetAsync(id);
            if(finance == null)
                throw new ValidationException("finance object not found by id");
            return finance.ToBll();
        }

        public async Task<List<FinanceDto>> GetAllAsync()
        {
            var list = await _unitOfWork.Finances.GetAllAsync();
            return list.ToBllFinances();
        }

        // Получаем обьект из Presentation Layer 
        public async Task CreateAsync(CreateFinanceDto dto)
        {
            await _unitOfWork.Finances.CreateAsync(dto.ToDalCreateFinance());
        }

        public async Task RemoveAsync(int id)
        {
            var finance = await _unitOfWork.Finances.GetAsync(id);
            if(finance == null)
                throw new ValidationException("finance not found");
            await _unitOfWork.Finances.DeleteAsync(finance);
        }

        public async Task UpdateAsync(EditFinanceDto dto, int id)
        {
            var finance = await _unitOfWork.Finances.GetAsync(id);
            if(finance == null)
                throw new ValidationException("finance not found");
            finance.Comment = dto.Comment;
            await _unitOfWork.Finances.UpdateAsync(finance);
        }
    }
}