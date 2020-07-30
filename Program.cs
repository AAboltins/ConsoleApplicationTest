using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    class Program
    {

        List<BankAccount> accounts = new List<BankAccount>();
        List<Human> persons = new List<Human>();
        static void Main(string[] args)
        {
            //create persons data
            Program p = new Program();
            p.persons.Add(new Human("Jenifer", "Lopez", 13, "Brunas"));
            p.persons.Add(new Human("Anna", "Skroderniece", 14, "Violetas"));
            p.persons.Add(new Human("Mikelis", "Mucinieks", 16, "Zilas"));
            p.persons.Add(new Human("Kristaps", "Kalejs", 17, "Zalas"));
            //create accounts here(note: you can not create new account if there is not profile that matches)
            int firstnumber = 12;
            p.accounts.Add(new BankAccount(p.persons[p.accounts.Count].Name + " " + p.persons[p.accounts.Count].Surname, 200, "EUR", firstnumber, 0));
            p.accounts.Add(new BankAccount(p.persons[p.accounts.Count].Name + " " + p.persons[p.accounts.Count].Surname, 200, "EUR", firstnumber, p.accounts.Count));
            p.accounts.Add(new BankAccount(p.persons[p.accounts.Count].Name + " " + p.persons[p.accounts.Count].Surname, 212300, "EUR", firstnumber, p.accounts.Count));
            p.accounts.Add(new BankAccount(p.persons[p.accounts.Count].Name + " " + p.persons[p.accounts.Count].Surname, 22300, "EUR", firstnumber, p.accounts.Count));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("write '/help' to view command list");
            Console.ForegroundColor = ConsoleColor.Blue;
            p.MainDiolog("");
        }
        private void MainDiolog_command(string command)
        {
            commands commands = new commands();
            if (command.Contains("/view.accountsdata[") && command.Substring(command.Length - 1) == "]" && command.Length >= 21)
            {
                if (command == "/view.accountsdata[all]")
                {
                    foreach (var account in accounts)
                    {
                        account.BankAccountInfo(false);
                    }
                }
                else
                {
                    int Tend2 = command.Length;
                    int numberLength2 = Tend2 - 20;
                    string char192 = command.Substring(19, numberLength2);
                    int Int;
                    if (Int32.TryParse(char192, out Int))
                    {
                        Int32.TryParse(char192, out Int);
                        if (Int > accounts.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index is to large!");
                            Console.WriteLine($"Note: Total number of accounts are {accounts.Count}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Int < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index can not be negative!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (command == $"/view.accountsdata[{i}]")
                            {
                                accounts[i - 1].BankAccountInfo(false);
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Index must be a number!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
            }
            else if (command == "/exit")
            {
                commands.Exit();
            }
            else if (command == "/help")
            {
                commands.Help();
            }
            else if (command == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("write '/help' to view command list");
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            else if (command == "/add.new_person")
            {
                AddNewPerson();
            }
            else if (command.Contains("/view.personsdata[") && command.Substring(command.Length - 1) == "]" && command.Length >= 20)
            {
                if (command == "/view.personsdata[all]")
                {
                    foreach (var person in persons)
                    {   
                        person.PersonInfo(false);
                    }
                }
                else
                {
                    int Tend = command.Length;
                    int numberLength = Tend - 19;
                    string char19 = command.Substring(18, numberLength);
                    int Int;
                    if (Int32.TryParse(char19, out Int))
                    {
                        Int32.TryParse(char19, out Int);
                        if (Int > persons.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index is to large!");
                            Console.WriteLine($"Note: Total number of persons profiles are {persons.Count}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Int < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index can not be negative!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        for (int i = 0; i < persons.Count; i++)
                        {
                            if (command == $"/view.personsdata[{i}]")
                            {
                                persons[i - 1].PersonInfo(false);
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Index must be a number!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
            }
            else
            {
                commands.Else(command);
            }
            MainDiolog("");
        }
        private void view(string codeline)
        {

        }
        private void MainDiolog(string command)
        {
            commands commands = new commands();
            bool end = false;


            while (end == false)
            {
                string line = Console.ReadLine();
                if (line.Contains("/view.accountsdata[") && line.Substring(line.Length - 1) == "]" && line.Length >= 21)
                {
                    if (line == "/view.accountsdata[all]")
                    {
                        foreach (var account in accounts)
                        {
                            account.BankAccountInfo(false);
                        }
                    }
                    else
                    {
                        int Tend2 = line.Length;
                        int numberLength2 = Tend2 - 20;
                        string char192 = line.Substring(19, numberLength2);
                        int Int;
                        if (Int32.TryParse(char192, out Int))
                        {
                            Int32.TryParse(char192, out Int);
                            if (Int > accounts.Count)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Index is to large!");
                                Console.WriteLine($"Note: Total number of accounts are {accounts.Count}");
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else if (Int < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Index can not be negative!");
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                if (line == $"/view.accountsdata[{i}]")
                                {
                                    accounts[i - 1].BankAccountInfo(true);
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index must be a number!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }
                }
                else if (line == "/exit")
                {
                    commands.Exit();
                }
                else if (line == "/help")
                {
                    commands.Help();
                }
                else if (line == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("write '/help' to view command list");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (line == "/add.new_person")
                {
                    AddNewPerson();
                }

                else if (line.Contains("/view.personsdata[") && line.Substring(line.Length - 1) == "]" && line.Length >= 20)
                {
                    if (line == "/view.personsdata[all]")
                    {
                        foreach (var person in persons)
                        {
                            person.PersonInfo(false);
                        }
                    }
                    else
                    {
                        int Tend = line.Length;
                        int numberLength = Tend - 19;
                        string char19 = line.Substring(18, numberLength);
                        int Int;
                        if (Int32.TryParse(char19, out Int))
                        {
                            Int32.TryParse(char19, out Int);
                            if (Int > persons.Count)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Index is to large!");
                                Console.WriteLine($"Note: Total number of persons profiles are {persons.Count}");
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else if (Int < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Index can not be negative!");
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            for (int i = 0; i < persons.Count; i++)
                            {
                                if (line == $"/view.personsdata[{i}]")
                                {
                                    persons[i - 1].PersonInfo(false);
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Index must be a number!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }
                }
                else
                {
                    commands.Else(line);
                }
            }    
        }
        public  void AddNewPerson()
        {
                Program p = new Program();
                string name = null;
                string surname = null;
                string ageinput = null;
                int age2;
                string eyecolor = null;
                bool End = false;


            while (End == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("new person.age:");
                Console.ForegroundColor = ConsoleColor.Blue;
                ageinput = Console.ReadLine();
                CheckStopAddNewPerson(ageinput);

                if (Int32.TryParse(ageinput, out age2))
                {
                    Int32.TryParse(ageinput, out age2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("new person.name:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    name = Console.ReadLine();
                    CheckStopAddNewPerson(name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("new person.surname:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    surname = Console.ReadLine();
                    CheckStopAddNewPerson(surname);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("new person.eyecolor:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    eyecolor = Console.ReadLine();
                    CheckStopAddNewPerson(eyecolor);

                    persons.Add(new Human(name, surname, age2, eyecolor));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{name} {surname} bank account:");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Balance:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string balance = null ;

                    string Currency = null;
                    bool stop = false;
                    int Ibalance;
                    while (stop == false)
                    {
                        balance = Console.ReadLine();
                        if (Int32.TryParse(balance, out Ibalance))
                        {
                            Int32.TryParse(balance, out Ibalance);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Currnecy:");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Currency = Console.ReadLine();
                            accounts.Add(new BankAccount(persons[accounts.Count].Name + " " + persons[accounts.Count].Surname, Ibalance, Currency, 12, accounts.Count));
                            stop = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Balance must be a number");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("View " + name + " profile together (Y/N)");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    bool End2 = false;
                    while (End2 == false)
                    {
                        string answer2 = Console.ReadLine();
                        CheckStopAddNewPerson(answer2);
                        if (answer2 == "Y")
                        {
                            persons[persons.Count - 1].PersonInfo(true);
                            End2 = true;
                            End = true;
                            MainDiolog("");

                        }
                        else if (answer2 == "N")
                        {
                             End2 = true;
                             End = true;
                             MainDiolog("");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This is Y/N n question");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            End2 = false;
                        } 

                    }
                }
                else
                {
                    Console.WriteLine("Age must be a number");
                }
                End = false;
            }
        }
        public void CheckStopAddNewPerson(string consoleline)
        {
            string firstchar = consoleline.Substring(0, 1);
            if(firstchar == "/")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("add.new_person() process exited and stoped");
                Console.ForegroundColor = ConsoleColor.Blue;
                MainDiolog_command(consoleline);
                Environment.Exit(0);
            }
        }

    }

}