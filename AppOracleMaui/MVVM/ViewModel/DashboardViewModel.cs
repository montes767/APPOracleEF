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

           var response= await App.TransactionRepository.GetAll();

            var data = response;


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
  

