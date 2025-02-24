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


    public class DashboardViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public DashboardViewModel()
        {
           
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
                    data.ForEach(trans => { Transactions.Add(trans); });
                }
            }

        }

        public async Task PonerCalculadora() {
            
               
            } 
    }
}