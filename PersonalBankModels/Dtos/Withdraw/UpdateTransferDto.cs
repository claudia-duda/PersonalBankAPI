using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBankModels.Dtos.Withdraw
{
    public class UpdateWithdrawDto
    {
        //TODO remove id to see if there is an error when update 
        public int Id { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
    }
}
