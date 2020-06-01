using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.DTO;
using WebAPI.BLL.Interfaces;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }
        
        [HttpGet]
        public async Task<List<FinanceDto>> GetAllAsync()
        {
            return await _financeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceDto>> GetAsync(int id)
        {
            return await _financeService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateFinanceDto dto)
        {
            await _financeService.CreateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            await _financeService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(EditFinanceDto dto,int id)
        {
            await _financeService.UpdateAsync(dto, id);
            return NoContent();
        }
    }
}