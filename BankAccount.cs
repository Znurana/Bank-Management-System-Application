using System;
namespace BankManagementSystem
{
	public class BankAccount
	{
        public int Number { get; set; }
        public string Owner { get; set; }
        public string Currency { get; set; }
        public float Balance { get; set; }
        

        public List<Transaction> Transactions = null;
        public BankAccount(string _ownerName)
		{
            Number = new Random().Next(10000, 99999);
            Owner = _ownerName;
            Currency = "Azn";
            Balance = 0;
            Transactions = new List<Transaction>();

		}

        public string MakeDeposit(float amount,DateTime date,string note)
        {
            this.Balance = this.Balance + amount;
             string responseMessage = $"{amount} {this.Currency} Deposit amount to balance";

            Transaction transaction = new Transaction(amount,date,note,TransactionType.Debit);

            Transactions.Add(transaction);
            return responseMessage;

        }

        public string MakeWithDraw(float amount, DateTime date, string note)
        {
            string responseMessage = string.Empty;
            if (this.Balance >= amount)
            {
              this.Balance = this.Balance - amount;
                responseMessage = $"Withdraw {amount}  from balance";
                Transaction transaction = new Transaction(amount, date, note, TransactionType.Credit);
                Transactions.Add(transaction);
            }
            
            else
            {
                responseMessage = $"No enough {amount} {this.Currency} money, Not successful";
            }
            return responseMessage;
        }

        
    }
}

