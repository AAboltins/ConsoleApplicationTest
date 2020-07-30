using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class commands
    {

        Program Progam = new Program();
        public commands()
        {

        }
        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting...?(WriteLine : 'confrimed' to exit)");
            Console.ForegroundColor = ConsoleColor.Blue;
            string answer = Console.ReadLine();
            if (answer == "/confirmed")
            {
                Environment.Exit(0);
            }
        }
        public void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("command :| /help ] to view the commands list");
            Console.WriteLine("command :| /view.accountsdata[all] | to show all accounts information ");
            Console.WriteLine("command :| /view.accountsdata[index of account wich you want to view( example: /view.accountsdata[1] )] | to show individual accaunts information");
            Console.WriteLine("command :| /view.personsdata[all] | to show all persons infromration");
            Console.WriteLine("command :| /view.personsdata[index of person wich data you want to view( example: /view.personsdata[1] )] | to show individual persons profile/information");
            Console.WriteLine("command :| /exit |, after that command | /confirmed | to exit from console");
            Console.WriteLine("Command :| /add.new_person ] to add new person");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void Else(string command)
        {
            Console.ForegroundColor
            = ConsoleColor.Red;
            Console.WriteLine($"there is no such command as {command}");
            Console.WriteLine("write |/help| to view command list");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
