using ModelOracleDemo;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppOracleMaui.MVVM.ViewModel
{

    public class TransactionsViewModel
    {

       public Transaction Trans { get; set; }= new Transaction();

        public async Task SaveTransaction()
        {
            HttpClient client = new HttpClient();

            JsonSerializerOptions _jsonOptions =
                new JsonSerializerOptions(JsonSerializerDefaults.Web);
            string url = "http://10.0.2.2:5190/transactions/";
            var json = JsonSerializer.Serialize<Transaction>(Trans, _jsonOptions);
            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
                );

            var response = await client.PostAsync(url, content);

        }
    }
}
