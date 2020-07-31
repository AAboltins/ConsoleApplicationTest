using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyFirstConsoleApplication
{
    class Human
    {
        private bool End = false;
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; private set; }
        public string EyeColor { get; }

        public Human(string name, string surname, int age, string eyecolor)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.EyeColor = eyecolor; 

        }
        public void PersonInfo(bool fullprofileinfo)
        {
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Name: " + this.Name);
            Console.WriteLine("Surname: " + this.Surname);
            Console.WriteLine("Age: " + this.Age);
            Console.WriteLine("Eyecolor: " + this.EyeColor);
            if (fullprofileinfo == false)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                fullprofileinfo = false;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void SayName()
        {
            Console.WriteLine(this.Name);
        }
        public void SetAge(int age)
        {
            if (age < 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The age can not be less than zero");
                this.Age = age;
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if(age < this.Age)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ("The new age for " + this.Name + " is younger are you sure you want to change the age");
                Console.ForegroundColor = ConsoleColor.Blue;
                while (End == false)
                {
                    string answer = Console.ReadLine();
                    if (answer == "yes" || answer == "Yes")
                    {
                        this.Age = age;
                        End = true;
                    }
                    else if (answer == "no" || answer == "No")
                    {
                        End = true;
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is yes or no question");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        End = false;
                    }
                }
            }
        }
    }
}
