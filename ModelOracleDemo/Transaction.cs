using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelOracleDemo
{
    
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; } 
        public DateTime OperationDate { get; set; }
    }
}
