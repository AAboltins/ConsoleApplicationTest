using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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
            commands commands = new commands();
            try
            {
                
                //create persons data
                Program p = new Program();
                p.persons.Add(new Human("Jenifer", "Lopez", 13, "Brunas"));
                p.persons.Add(new Human("Anna", "Skroderniece", 14, "Violetas"));
                p.persons.Add(new Human("Mikelis", "Mucinieks", 16, "Zilas"));
                p.persons.Add(new Human("Kristaps", "Kalejs", 17, "Zalas"));
                //create accounts here(note: you can not create new account if there is not profile that matches)
                int firstnumber = 12;
                p.accounts.Add(new BankAccount($"{ p.persons[p.accounts.Count].Name} {p.persons[p.accounts.Count].Surname }", 200, "EUR", firstnumber, 0));
                p.accounts.Add(new BankAccount($"{ p.persons[p.accounts.Count].Name} {p.persons[p.accounts.Count].Surname }", 200, "EUR", firstnumber, p.accounts.Count));
                p.accounts.Add(new BankAccount($"{ p.persons[p.accounts.Count].Name} {p.persons[p.accounts.Count].Surname }", 212300, "EUR", firstnumber, p.accounts.Count));
                p.accounts.Add(new BankAccount($"{ p.persons[p.accounts.Count].Name} {p.persons[p.accounts.Count].Surname }", 22300, "EUR", firstnumber, p.accounts.Count));
                commands.WriteLine("to view the command list write |/help|");
                p.ExtraLineProblem("");
            }
            catch
            {
                commands.ErrorMessage("[accounts] cannot be more than [persons], they need to be the same count!");
                commands.ErrorMessage("delete extra [accounts] or create new [persons] and then restart console!");
                commands.ErrorMessage("press key Enter to close console!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        private void ExtraLineProblem(string command)
        {
            //if MainDiolog() is called by CheckStopAddNewPerson() then after typed command will show only extraline, because of string line = Console.ReadLine(). ExtraLineProblem() method solves this by  checing
            //if sender is CheckStopAddNewPerson(), if so then it doesnt create new line it uses the command that was typed while AddingNewPerson.
            if (command == "")
            {
                string line = Console.ReadLine();
                MainDiolog(line, true);
            }
            else
            {
                MainDiolog(command, true);
            }
        }
        public void view(string codeline, string listelements)
        {
            
            if (codeline == "/view.personsdata[all]")
            {
                Console.WriteLine(codeline);
                foreach (var person in persons)
                {
                    person.PersonInfo(false);
                }
            }
            else if (codeline == "/view.accountsdata[all]")
            {
                foreach (var account in accounts)
                {
                    account.BankAccountInfo(false);
                }
            }
            else if (codeline == "/view.profiledata[all]")
            {
                foreach (var person in persons)
                {
                    person.PersonInfo(true);
                }
                foreach (var account in accounts)
                {
                    account.BankAccountInfo(true);
                }
            }
            else
            {
                commands commands = new commands();
                int stringLength = codeline.Length;
                int numberLength = stringLength - listelements.Length - 12;
                string char19 = codeline.Substring((listelements.Length + 11), numberLength);
                Console.WriteLine(char19);
                int Int;
                if (Int32.TryParse(char19, out Int))
                {
                    Int32.TryParse(char19, out Int);
                    if (Int > persons.Count)
                    {
                        commands.ErrorMessage_ToLargeNum(listelements, persons.Count);
                    }
                    else if (Int < 0)
                    {
                        commands.ErrorMessage("[index] cannot be negative!");
                    }
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (codeline == $"/view.personsdata[{i}]")
                        {
                            persons[i - 1].PersonInfo(false);
                        }
                        else if (codeline == $"/view.accountsdata[{i}]")
                        {
                            accounts[i - 1].BankAccountInfo(false);
                        }
                        else if (codeline == $"/view.fullprofiledata[{i}]")
                        {
                            persons[i - 1].PersonInfo(true);
                            accounts[i - 1].BankAccountInfo(true);
                        }
                    }
                }
                else
                {
                    //checking if realy in char19 is some string or if just char19 is so  big number, it cannot even store in Int32
                    bool numbertolarge = true;
                    for(int c = 0; c < char19.Length; c ++)
                    {
                        string checknumber = char19.Substring(c, 1);
                        int Ichecknumber;
                        if(!Int32.TryParse(checknumber, out Ichecknumber))
                        {
                            numbertolarge = false;
                            break;
                        }
                    }
                    if(numbertolarge == true)
                    {
                        commands.ErrorMessage_ToLargeNum(listelements, persons.Count);
                    }
                    else
                    {
                        commands.ErrorMessage("[index] must be a number!");
                    }
                }
            }
            ExtraLineProblem("");
        }
        private void MainDiolog(string line, bool ExtraLineProblemSender)
        {
            commands commands = new commands();
            bool end = false;
            while (end == false)
            {
                if (ExtraLineProblemSender == false)
                {
                    ExtraLineProblem("");
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
                    commands.WriteLine("write '/help' to view command list");
                }
                else if (line == "/add.new_person")
                {
                    AddNewPerson();
                }
                else if (line == "test")
                {
                    persons[1].PersonInfo(false);
                }
                else if (line.Contains("/view") && line.Substring(line.Length - 1, 1) == "]")
                {
                    commands.Check(line);
                    if(commands.check == true)
                    {
                        view(line, commands.returnlistelemnts);
                    }
                    else
                    {
                        commands.Else(line);
                    }
                }
                else
                {
                    commands.Else(line);
                }
                ExtraLineProblemSender = false;
            }
        }
        public void AddNewPerson()
        {
            Program p = new Program();
            commands commands = new commands();
            string name = null;
            string surname = null;
            string ageinput = null;
            int age2;
            string eyecolor = null;
            bool End = false;

            while (End == false)
            {
                commands.WriteLine("new person.age:");
                ageinput = Console.ReadLine();
                CheckStopAddNewPerson(ageinput);

                if (Int32.TryParse(ageinput, out age2))
                {
                    Int32.TryParse(ageinput, out age2);

                    commands.WriteLine("new person.name:");
                    name = Console.ReadLine();
                    CheckStopAddNewPerson(name);

                    commands.WriteLine("new person.surname:");
                    surname = Console.ReadLine();
                    CheckStopAddNewPerson(surname);

                    commands.WriteLine("new person.eyecolor:");
                    eyecolor = Console.ReadLine();
                    CheckStopAddNewPerson(eyecolor);

                    persons.Add(new Human(name, surname, age2, eyecolor));

                    commands.WriteLine($"{name} {surname} bank account:");
                    commands.WriteLine("Balance:");

                    string balance = null;
                    string Currency = null;
                    bool stop = false;
                    int Ibalance;
                    while (stop == false)
                    {
                        balance = Console.ReadLine();
                        if (Int32.TryParse(balance, out Ibalance))
                        {
                            Int32.TryParse(balance, out Ibalance);
                            commands.WriteLine("Currnecy:");
                            Currency = Console.ReadLine();

                            accounts.Add(new BankAccount($"{persons[accounts.Count].Name} {persons[accounts.Count].Surname}", Ibalance, Currency, 12, accounts.Count));
                            stop = true;
                        }
                        else
                        {
                            commands.ErrorMessage("balance must be a number!");
                        }
                    }
                    commands.WriteLine("view " + name + " profile together (Y/N)");

                    bool End2 = false;
                    while (End2 == false)
                    {
                        string answer2 = Console.ReadLine();
                        CheckStopAddNewPerson(answer2);

                        if (answer2 == "Y")
                        {
                            persons[persons.Count - 1].PersonInfo(true);
                            accounts[persons.Count - 1].BankAccountInfo(true);
                            End2 = true;
                            End = true;
                            ExtraLineProblem(""); ;

                        }
                        else if (answer2 == "N")
                        {
                            End2 = true;
                            End = true;
                            ExtraLineProblem(""); ;
                        }
                        else
                        {
                            commands.ErrorMessage("this is Y/N n question!");
                            End2 = false;
                        }
                    }
                }
                else
                {
                  commands.ErrorMessage("age must be a number!");
                }
            }
        }
        public void CheckStopAddNewPerson(string consoleline)
        {
            //checking if user is typing command while creating new persons account to avoid this mistake : "Name:/(command)"
            string firstchar = consoleline.Substring(0, 1);
            if (firstchar == "/")
            {
                commands commands = new commands();
                commands.ErrorMessage("add.new_person() process exited and stoped!");
                ExtraLineProblem(consoleline);
            }
        }
    }
}