using AppOracleMaui.MVVM.Model;
using ModelOracleDemo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AppOracleMaui.MVVM.ViewModel
{
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary> Summary { get; set; } = new ObservableCollection<TransactionsSummary>();

        public ObservableCollection<Transaction> SpendingList { get; set; } = new ObservableCollection<Transaction>();



        public async Task<List<Transaction>> GetTransactions()
        {
            List<Transaction> trans = new List<Transaction>();
            HttpClient client = new HttpClient();

            JsonSerializerOptions _jsonOptions =
                new JsonSerializerOptions(JsonSerializerDefaults.Web);
            string url = "http://10.0.2.2:5173/Transactions";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    trans = await JsonSerializer
                        .DeserializeAsync<List<Transaction>>(stream, _jsonOptions)
                         ?? new List<Transaction>();
                }
            }
            return trans;
        }
    public async Task GetTransactionsSummary()
        {
            var data = await GetTransactions();
            var result = new List<TransactionsSummary>();

            var groupedTransactions = data.GroupBy(t => t.OperationDate.Date);

            foreach (var group in groupedTransactions)
            {
                var transactionSumary = new TransactionsSummary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
                    ShownDate = group.Key.ToString("MM/dd")
                };
                result.Add(transactionSumary);
            }
            result = result.OrderBy(ts => ts.TransactionsDate).ToList();
            result.ForEach(t => Summary.Add(t));
            var spendings = data.Where(t => !t.IsIncome).ToList();
            spendings.ForEach(s => SpendingList.Add(s));
        }
    }
}

