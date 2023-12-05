using System;
namespace BankManagementSystem
{
	public class Transaction
	{
        public TransactionType TransactionType { get; set; }
        public DateTime OperationDate { get; set; }
		public float Amount { get; set; }
		public string Note { get; set; }


       public Transaction(float amount, DateTime date, string note,TransactionType type)
		{
			this.Amount = amount;
			this.OperationDate = date;
			this.Note = note;
			this.TransactionType = type;
		}

    }

}

