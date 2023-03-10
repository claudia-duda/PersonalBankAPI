
namespace PersonalBankModels.Dtos.Deposit
{   
    public class CreateDepositDto
    {
        public float Amount { get; set; }
        public int AccountNumber { get; set; }
        public string? Description { get; set; }
        public DateTime dateTransaction { get; set; }
    }
}
