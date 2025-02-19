using Bogus;
using Microsoft.EntityFrameworkCore;
using ModelOracleDemo;

namespace WebApiEfOracle
{
    public class OracleContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public OracleContext() {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                "Data Source=10.0.255.1:1521/pdb1;User Id=ADRIAN;Password=ADRIAN;Validate Connection=true;"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().Property(t => t.IsIncome).HasConversion<int>();
            //modelBuilder.Entity<Transaction>().HasData(GetTransactions());
        }

        private List<Transaction> GetTransactions()
        {
            var transactions= new List<Transaction>();
            for (int i = 1; i<100; i++)
            {
                var t= new Faker<Transaction>()
                    .RuleFor(t=>t.Id, f=> i)
                    .RuleFor(t=>t.Name, f=> f.Company.CompanyName())
                    .RuleFor(t=> t.Amount, f=>f.Random.Decimal(0,10000))
                    .RuleFor(t=> t.IsIncome, f=> f.Random.Bool())
                    .RuleFor(t=>t.OperationDate, f=> f.Date.Past())
                    .Generate();
                transactions.Add(t);
                    
            }
            return transactions;

        }

    }
}
