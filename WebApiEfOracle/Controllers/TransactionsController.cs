using Bogus.Extensions.UnitedKingdom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using ModelOracleDemo;


namespace WebApiEfOracle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly OracleContext _oracleContext = new OracleContext();

        public TransactionsController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get()
        {
            var transactions = await _oracleContext.Transactions.ToListAsync();
            return transactions;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {

            _oracleContext.Transactions.Add(transaction);
            await _oracleContext.SaveChangesAsync();
            return Ok(transaction);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Transaction trans)
        {
            var existingTransaction = await _oracleContext.Transactions.FindAsync(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            
            _oracleContext.Entry(existingTransaction).CurrentValues.SetValues(trans);

            await _oracleContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var transaction = await _oracleContext.Transactions.FindAsync(id);
            if (transaction==null)
            {
                return NotFound();
            }
            else
            {
                _oracleContext.Transactions.Remove(transaction);
                await _oracleContext.SaveChangesAsync();
                return NoContent();
            }

           



        }
    }
}
