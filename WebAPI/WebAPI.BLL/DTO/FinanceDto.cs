namespace WebAPI.BLL.DTO
{
    public class FinanceDto
    {
        public int Id { get; set; }
        public string DebtorId { get; set; } // должник
        public string UserId { get; set; } // кто одолжил деньги
        public decimal Amount { get; set; } // сколько должен
        public string Comment { get; set; } 
    }
}