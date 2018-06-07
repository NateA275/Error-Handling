using System;

namespace Bank_Account
{
    public class Program
    {
        public static decimal balance = 5000;
        public static string receipt = $"TRANSACTION RECEIPT\n\t\t\t{balance.ToString("C2")}\n";

        public static void Main(string[] args)
        {
            bool runFlag = true;
            while (runFlag)
            {
                Console.Clear();
                Menu(); //Display Menu To User
                try
                {
                    int choice = MenuOption(); //Get User input
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ViewBalance();
                            break;
                        case 2:
                            Withdraw();
                            break;
                        case 3:
                            Deposit();
                            break;
                        case 4:
                            runFlag = false;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            PrintReceipt();
        }

        //Display menu to User
        public static void Menu()
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");
        }
        
        //Retrive User's Menu Choice
        public static int MenuOption()
        {
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 4 || choice < 1)
                {
                    Console.WriteLine("Please Select From the Options Listed Above.");
                    choice = MenuOption();
                }
                return choice;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Display Current Account Balance to User
        public static void ViewBalance()
        {
            Console.WriteLine($"Current Balance:\t{balance.ToString("C2")}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        //Decrement Current Balance
        public static void Withdraw()
        {
            Console.Clear();
            try
            {
                Console.Write("Withdraw ");
                decimal amount = GetAmount();
                if (amount > balance)
                    Console.WriteLine("Insufficient Funds");
                else
                {
                    balance -= amount;
                    Transaction($"-{amount.ToString("C2")}");
                }
                ViewBalance();
            }
            catch
            {
                throw;
            }
        }


        //Increment Current Balance
        public static void Deposit()
        {
            Console.Clear();
            try
            {
                Console.Write("Depisit ");
                decimal amount = GetAmount();
                balance += amount;
                Transaction($"+{amount.ToString("C2")}");
                ViewBalance();
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Request amount from user
        public static decimal GetAmount()
        {
            try
            {
                Console.Write("Amount: $");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                if (amount < 0)
                {
                    Console.WriteLine("Enter a Positive Amount");
                    amount = GetAmount();
                }

                return amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Store Session Transaction History
        public static void Transaction(string record)
        {
            receipt += $"\t\t\t{record}\n";
        }

        //Display Transaction Histroy
        public static void PrintReceipt()
        {
            Console.Clear();
            Console.WriteLine(receipt);
            ViewBalance();
        }
    }
}
