using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBankModels.Dtos.Withdraw
{   
    public class CreateWithdrawDto
    {
        public float Amount { get; set; }
        public string? Description { get; set; }
        public DateTime dateTransaction { get; set; }
    }
}
