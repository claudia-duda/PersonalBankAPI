using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBankModels.Models
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
    }
}
