using System;

namespace myApp
{
    class BankAccount
    {
        private string accountNumber;
        private string accountHolderName;
        private double balance;

        public BankAccount(string number, string name, double initialBalance)
        {
            accountNumber = number;
            accountHolderName = name;
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount}. New Balance: {balance}");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {balance}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Balance: {balance}");
        }
    }

    // Interact with the user
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("12345", "Aditya", 1000);

            account.Deposit(500);
            account.Withdraw(200);
            account.CheckBalance();
        }
    }
}
