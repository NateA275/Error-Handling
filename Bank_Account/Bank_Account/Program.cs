using System;
using System.Text;

namespace Bank_Account
{
    public class Program
    {
        public static decimal balance = 5000;
        public static StringBuilder receipt = new StringBuilder($"TRANSACTION RECEIPT\n\t\t\t{GetBalance().ToString("C2")}\n");

        public static void Main(string[] args)
        {
            bool runFlag = true;
            while (runFlag)
            {
                Menu();
                try
                {
                    int choice = MenuOption();

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
                finally
                {
                    Console.Clear();
                }
            }

            PrintReceipt();
        }

        /// <summary>
        /// GetBalance - Retrieve Current Balanace
        /// </summary>
        /// <returns> decimal - current balance </returns>
        public static decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// AddToBalance - Increment Current Balance
        /// </summary>
        /// <param name="amount"> decimal - positive amount to be added to balance </param>
        /// <returns> decimal - incremented balance </returns>
        public static decimal AddToBalance(decimal amount)
        {
            return balance += amount;
        }

        /// <summary>
        /// SubtractFromBalance - Decrement Current Balance
        /// </summary>
        /// <param name="amount"> decimal - positive amount to be subtraced from balance </param>
        /// <returns> decimal - decremented balance </returns>
        public static decimal SubtractFromBalance(decimal amount)
        {
            return balance -= amount;
        }

        /// <summary>
        /// Menu - Display ATM interface to user
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");
        }
        
        /// <summary>
        /// MenuOption - Validate user's menu option selection
        /// </summary>
        /// <returns> int - selected menu option </returns>
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

        /// <summary>
        /// ViewBalance - Display current balance to the console in an appropriate format
        /// </summary>
        public static void ViewBalance()
        {
            Console.WriteLine($"Current Balance:\t{GetBalance().ToString("C2")}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        /// <summary>
        /// Withdraw - Retrieve user input amount, validate value, and decrement current balance
        /// </summary>
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
                    SubtractFromBalance(amount);
                    Transaction($"-{amount.ToString("C2")}");
                }
                ViewBalance();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Depost - Retrieve user input amount, validate value, and increment current balance
        /// </summary>
        public static void Deposit()
        {
            Console.Clear();
            try
            {
                Console.Write("Depisit ");
                decimal amount = GetAmount();
                AddToBalance(amount);
                Transaction($"+{amount.ToString("C2")}");
                ViewBalance();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        /// <summary>
        /// GetAmount - Retrieve validated amount from user
        /// </summary>
        /// <returns> decimal - validated monetary representation to be added/subtracted from current balance </returns>
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

        /// <summary>
        /// Transaction - Accumulate all transaction records for current ATM session
        /// </summary>
        /// <param name="record"> string - single transaction amount in currecny format with a leading +/- </param>
        public static void Transaction(string record)
        {
            receipt.Append($"\t\t\t{record}\n");
        }

        /// <summary>
        /// PrintReceipt - Display all session transactions to user via console
        /// </summary>
        public static void PrintReceipt()
        {
            Console.Clear();
            Console.WriteLine(receipt.ToString());
            ViewBalance();
        }
    }
}
