using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
