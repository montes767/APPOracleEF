using ModelOracleDemo;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppOracleMaui.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]

    public class DashboardViewModel
    {

        public decimal Incomes { get; set; }
        public decimal Expenses { get; set; }
        public decimal Balance { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        
        
        
        
        public DashboardViewModel()
        {
            var task = Task.Run(async () => { await GetTransactions(); });

            task.Wait();
        
        }

        public async Task GetTransactions()
        {
            HttpClient client = new HttpClient();

            JsonSerializerOptions _jsonOptions =
                new JsonSerializerOptions(JsonSerializerDefaults.Web);
            string url = "http://10.0.2.2:5173/Transactions/";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                        .DeserializeAsync<List<Transaction>>(stream, _jsonOptions) ?? new List<Transaction>();


                    Transactions.Clear();
                    
                    data.ForEach(t =>
                    {
                        Transactions.Add(t);
                        if (t.IsIncome)
                        {
                            Incomes += t.Amount;
                        }
                        else
                        {
                            Expenses += t.Amount;
                        }

                    });
                    Balance = Incomes - Expenses;

                }
            }

        }

      
    }
}