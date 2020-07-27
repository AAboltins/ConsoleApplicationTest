using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    class Program
    {
        List<Human> persons = new List<Human>();
        static void Main(string[] args)
        {

            Program p = new Program();

            p.persons.Add(new Human("Amanda", "Robezniece", 32, "zilas"));
            p.persons.Add(new Human("Karlis", "Ziema", 12, "brunas"));
            p.persons.Add(new Human("Laura", "Babrova", 22, "dzeltenas"));

            foreach (var person in p.persons)
            {
                person.Introduce();
            }
            p.CreateNewHuman();
            // persons[1] = new Human("ss", "Kla", 12, "zASDA");
            //person[0].Introduce();
            //person[1].Introduce();
            //person[2].Introduce();
            //person[3].Introduce();
            //=
            //|
            //V
            //for (int i = 0; i < persons.Count; i++)
            //{
            //    persons[i].Introduce();
            //}
            // = 
            //|
            //V

        }
        private void CreateNewHuman()
        {
            string name = null;
            string surname = null;
            string ageinput = null;
            int age2;
            bool intruduction = true;
            string eyecolor = null;
            bool End = false;

            while (End == false)
            {

                if (intruduction == true)
                {
                    Console.WriteLine("Do you want to create new person?");
                }
                else
                {
                    Console.WriteLine("Do you want to try again");
                }

                string answer = Console.ReadLine();
                if (answer == "yes")
                {
                    Console.WriteLine("ok");
                    Console.WriteLine("Age:");

                    ageinput = Console.ReadLine();

                    if (Int32.TryParse(ageinput, out age2))
                    {
                        Int32.TryParse(ageinput, out age2);
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();

                        Console.WriteLine("Surname:");
                        surname = Console.ReadLine();

                        Console.WriteLine("Eyecolor:");
                        eyecolor = Console.ReadLine();

                        persons.Add(new Human(name, surname, age2, eyecolor));
                        string lastCharacter = name.Substring(name.Length - 1);
                        if (lastCharacter == "s" || lastCharacter == "o")
                        {
                            Console.WriteLine("Do you want to " + name + " Introduce him self?");
                        }
                        else
                        {
                            Console.WriteLine("Do you want to " + name + " Introduce her self?");
                        }

                        bool End2 = false;
                        while (End2 == false)
                        {
                            string answer2 = Console.ReadLine();
                            if (answer2 == "yes")
                            {
                                Console.WriteLine("ok");
                                persons[persons.Count - 1].Introduce();
                                End2 = true;
                            }
                            else if (answer2 == "no")
                            {
                                Console.WriteLine("ok");
                                End2 = true;
                            }
                            else if (answer2 == "Introduce them all")
                            {
                                Console.WriteLine("ok");
                                for (int i = 0; i < persons.Count; i++)
                                {
                                    persons[i].Introduce();
                                }
                                End2 = true;
                            }
                            else
                            {
                                Console.WriteLine("This is yes or no question");
                                End2 = false;
                            }

                        }
                        intruduction = true;
                    }
                    else
                    {
                        Console.WriteLine("Age must be a number");
                        intruduction = false;
                    }
                    End = false;
                }
                else if (answer == "no")
                {
                    Console.WriteLine("ok");
                    End = true;
                    return;

                }
                else
                {
                    Console.WriteLine("This is yes or no question");
                    End = false;
                    intruduction = true;
                }

            }
            intruduction = true;
            End = false;
        }

    }

}