
namespace PersonalBankModels.Models
{
    public abstract class Transaction
    { 
        public int Id { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public DateTime dateTransaction { get; set; }
    }
}
