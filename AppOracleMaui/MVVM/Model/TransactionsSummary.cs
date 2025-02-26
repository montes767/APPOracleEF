using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOracleMaui.MVVM.Model
{
    public class TransactionsSummary
    {
        public DateTime TransactionsDate { get; set; }

        public string ShownDate { get; set; } = string.Empty;

        public decimal TransactionsTotal { get; set; }
    }
}
