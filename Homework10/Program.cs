using System;
using System.Collections.Generic;

namespace Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfPersons = 3;
            List<Person> people = new List<Person>();
            for (int i = 0; i < numberOfPersons; i++)
            {
                Console.Write($"Enter name {i}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter age {i}: ");

                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    if (age > 0)
                    {
                        var person = new Person
                        {
                            Name = name,
                            Age = age
                        };
                        people.Add(person);
                    }
                    else
                        Console.WriteLine("Возраст должен быть > 0");
                }
                else
                    Console.WriteLine("Неверный формат возраста!");
            }
            people.ForEach((p) =>
            {
                Console.WriteLine(p.Description);
            });
            Console.ReadKey();
        }
    }
}
