using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class commands
    {
        public bool check { get; private set; }
        public string returnlistelemnts { get; private set; }
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
        public void Check( string command)
        {
            string listelements1 = null;
            for (int x = 0; x < 4; x++)
            {
                if (x == 1) { listelements1 = "persons"; }
                else if (x == 2) { listelements1 = "fullprofile"; }
                else if (x == 3) { listelements1 = "accounts"; }
                if (command.Substring(command.Length - 1, 1) == "]" && command.Length >= 20 && command.Contains($"/view.{listelements1}data["))
                {
                    check = true;
                    returnlistelemnts = listelements1;
                }
            }
            //Else(command);

        }
        public void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("command :| /help ] to view the commands list");
            Console.WriteLine("command :| /view.accountsdata[all] | to show all accounts information ");
            Console.WriteLine("command :| /view.accountsdata[index of account wich you want to view( example: /view.accountsdata[1] )] | to show individual accounts information");
            Console.WriteLine("command :| /view.personsdata[all] | to show all persons infromration");
            Console.WriteLine("command :| /view.personsdata[index of person wich data you want to view( example: /view.personsdata[1] )] | to show individual persons information");
            Console.WriteLine("command :| /view.fullprofile[all] | to shows all full profiles infromration");
            Console.WriteLine("command :| /view.fullprofiledata[index of profile wich data you want to view( example: /view.fullprofilesdata[1] )] | to show individual profile information");
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
        public void ErrorMessage_ToLargeNum(string listelement2, int personscount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[index] is to large!");
            Console.WriteLine($"Note: total number of {listelement2} are {personscount}");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void ErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void WriteLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
