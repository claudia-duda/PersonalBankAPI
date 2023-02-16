

namespace PersonalBankModels.Dtos.Deposit
{
    public class UpdateDepositDto
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
    }
}
