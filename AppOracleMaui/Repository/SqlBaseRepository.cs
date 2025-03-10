
using SQLite;



namespace AppOracleMaui.Repository
{
   public class SqlBaseRepository<T> : IBaseRepository<T> where T : TableData, new()
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
            try
            {
                if (item.Id == 0)
                {
                    int rows = _connection.Insert(item);
                    StatusMessage = $"Added: {rows}";
                }
                else
                {
                    int rows = _connection.Update(item);
                    StatusMessage = $"Updated: {rows}";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";

            }
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _connection.Table<T>().ToList();
        }
    }
}
