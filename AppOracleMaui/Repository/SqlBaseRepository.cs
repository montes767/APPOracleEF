
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace AppOracleMaui.Repository
{
    public class SqlBaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// Connection to database
        /// </summary>
        private static SQLiteConnection _connection;
        static SqlBaseRepository()
        {
           _connection= new SQLiteConnection(constants.DatabasePath, constants.flags);

        }

        public string StatusMessage { get; set; } = string.Empty;

        public SqlBaseRepository()
        {
            _connection.CreateTable<T>();
            
        }

        public void Save(T item)
        {
          
                    int rows = _connection.Insert(item);
                    StatusMessage = $"Added: {rows}";
                
                    int rows1 = _connection.Update(item);
                    StatusMessage = $"Updated: {rows1}";
               
          
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }



       

       public Task<List<T>> GetAll()
        {
            return Task.FromResult(_connection.GetAllWithChildren<T>());
        }
    }
}
