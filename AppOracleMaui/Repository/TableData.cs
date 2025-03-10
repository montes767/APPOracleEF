using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppOracleMaui.Repository
{
    public abstract class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

    }
}
