using System;
using BankManagementSystem.Enum;
namespace BankManagementSystem;

class Program
{
    private static int menu;
    private static BankAccount currentAccount = null;
   

    static void Main(string[] args)
    {
        showMenu();
    }
  
    public static void showMenu()
    {
        do
        {
            menuList();
            menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                   Console.WriteLine($"You choose this   : { MenuList.CreateAccount} menu"); //String Interpolation
                    currentAccount = CreateNewCustomer();
                    break;
                case 2:
                    Console.WriteLine($"You choose this   : {MenuList.DepositMoney} menu");
                    IncreaseBalance(currentAccount);
                    break;
                case 3:
                    Console.WriteLine($"You choose this   : {MenuList.WithdrawingMoney} menu");
                    DecreaseBalance(currentAccount);
                    break;
                case 4:
                    Console.WriteLine($"You choose this   : {MenuList.ShowBalance} menu");
                    ShowBalance(currentAccount);
                    break;
                case 5:
                    Console.WriteLine($"You choose this  : {MenuList.ShowBalanceHistory} menu");
                    ShowTransaction(currentAccount);
                    break;
                case 6:
                    Console.WriteLine($"You choose this   : {MenuList.Exit} menu");
                    return;
                default:
                    break;
            }

    } while (menu != 6);

    }

    public static void menuList()
    {
        Console.WriteLine("1. Create new account ");
        Console.WriteLine("2. Deposit Money ");
        Console.WriteLine("3. Withdrawing money ");
        Console.WriteLine("4. Show Balance ");
        Console.WriteLine("5. Show balance history ");
        Console.WriteLine("6. Exit ");

    }

    public static BankAccount CreateNewCustomer() //BankAccout return type
    {
        Console.WriteLine("Enter your name and surname");
        //Console.WriteLine("Ata adını daxil edin");

        string customerName=Console.ReadLine();
        Console.WriteLine($"Name :{customerName}");
        BankAccount account = new BankAccount(customerName);

        return account;
    }

    public static void IncreaseBalance(BankAccount account)
    {

        Console.WriteLine("Enter amount :");
        float amount = float.Parse(Console.ReadLine());
         string response= account.MakeDeposit(amount, DateTime.Now, "Deposit");
        Console.WriteLine(response);
    }

    public static void DecreaseBalance(BankAccount account)
    {
        Console.WriteLine("Enter withdraw amount :");
        float amount = float.Parse(Console.ReadLine());

        string response= account.MakeWithDraw(amount, DateTime.Now, "withdraw");
        Console.WriteLine(response);

    }
    public static void ShowBalance(BankAccount account)
    {
        float balance = account.Balance;
        Console.WriteLine($"Current balance {balance} {account.Currency}" );
    }

    public static void ShowTransaction(BankAccount account)
    {
        string accountInfo = $"{account.Owner} this  {account.Number} operations";
        List<Transaction> accountTransactions = account.Transactions;

        foreach (var item in accountTransactions)
        {
            string transactionInfo = $"Operation date: {item.OperationDate} Operation type: {item.TransactionType} - Amount: {item.Amount} - Note: {item.Note}";
            if (item.TransactionType == TransactionType.Debit)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(transactionInfo);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(transactionInfo);
            }
            Console.ResetColor();

        }
    }


}



