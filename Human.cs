using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp
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
        public void CreateNewPerson() { 
        }
        public void Introduce()
        {
            Console.WriteLine("Hi, my full name is " + this.Name + " " + this.Surname + "." + "I am " + this.Age + " years old");
        }
        public void AddNumbers(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void SayName()
        {
            Console.WriteLine(this.Name);
        }
        public void SetAge(int age)
        {
            
            if (age < 0)
            {
                Console.WriteLine("The age can not be less than zero");
                this.Age = age;
            }
            else if(age < this.Age)
            {
                Console.WriteLine ("The new age for " + this.Name + " is younger are you sure you want to change the age");
                while (End == false)
                {
                    string answer = Console.ReadLine();
                    if (answer == "yes" || answer == "Yes")
                    {
                        Console.WriteLine("ok");
                        this.Age = age;
                        End = true;
                    }
                    else if (answer == "no" || answer == "No")
                    {
                        Console.WriteLine("ok");
                        End = true;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("This is yes or no question");
                        End = false;
                    }
                    End = false;
                }
            }
        }
    }
}
