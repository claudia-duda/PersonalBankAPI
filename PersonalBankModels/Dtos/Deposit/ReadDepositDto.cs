

namespace PersonalBankModels.Dtos.Deposit
{
    public class ReadDepositDto
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public int AccountNumber { get; set; }
        public DateTime dateTransaction { get; set; }
    }
}
