using Microsoft.EntityFrameworkCore;
using ModelOracleDemo;
namespace WebApiEfOracle.Repositoriesd
{
    public class OracleContext : DbContext
    {
        public IList<Student> Students { get; set; }= new List<Student>();

        public override void OnConfiguring()
        {

        }
    }
}
