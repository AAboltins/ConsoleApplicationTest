using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Human> persons = new List<Human>();

            
            persons.Add(new Human("Jenifer", "Lopez", 13, "Brunas"));
            persons.Add(new Human("Anna", "Skroderniece", 14, "Violetas"));
            persons.Add(new Human("Mikelis", "Mucinieks", 16, "Zilas"));
            persons.Add(new Human("Kristaps", "Kalejs", 17, "Zalas"));
            persons[1].SetAge(2);

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
            
            foreach (var person in persons)
            {
                person.Introduce();
            }
        }
      
    }

}