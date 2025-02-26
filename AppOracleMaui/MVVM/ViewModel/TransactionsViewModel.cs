using ModelOracleDemo;
using PropertyChanged;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppOracleMaui.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class TransactionsViewModel
    {

       public Transaction Trans { get; set; }= new Transaction();
        public TransactionsViewModel()
        {
            
        }
        //public TransactionsViewModel(Transaction trans)
        //{
        //    Trans = trans;
        //}
        public async Task SaveTransaction()
        {
            HttpClient client = new HttpClient();

            JsonSerializerOptions _jsonOptions =
                new JsonSerializerOptions(JsonSerializerDefaults.Web);
            string url = "http://10.0.2.2:5173/Transactions";
            var json = JsonSerializer.Serialize<Transaction>(Trans, _jsonOptions);
            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
                );

            var response = await client.PostAsync(url, content);

        }
        public async Task CancelTransaction()
        {

        }

        internal async Task change()
        {
            throw new NotImplementedException();
        }
    }
}
