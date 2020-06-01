using System;

namespace WebAPI.DAL.Entities
{
    public class Finance
    {
        public int Id { get; set; }
        
        public virtual User Debtor { get; set; }
        public string DebtorId { get; set; } // должник

        public virtual User User { get; set; }
        public string UserId { get; set; } // кто одолжил деньги
        public decimal Amount { get; set; } // сколько должен

        public DateTime Date { get; set; }
        public string Comment { get;set; }
    }
}