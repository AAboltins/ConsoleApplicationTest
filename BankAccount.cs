using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class BankAccount
    {

        public int Number { get; }
        public string Owner { get; }
        public decimal Balance { get; }
        public DateTime Created { get; }
        public string Currancy { get; }
        
        public BankAccount( string owner ,decimal balance, string currancy, int firstnumber, int thisindex)
        {

            this.Owner = owner;
            this.Number = firstnumber + thisindex;
            this.Balance = balance;
            this.Currancy = currancy;
            this.Created = DateTime.Now;

        }
        public void BankAccountInfo(bool fullprofile) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (fullprofile == false)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            Console.WriteLine($"Account number {this.Number} created on {this.Created.ToShortDateString()} belongs to {this.Owner} with a balance {this.Balance} {this.Currancy}");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

    }
}
