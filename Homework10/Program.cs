using System;
using System.Collections.Generic;

namespace Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name {i}: ");
                string name = Console.ReadLine();

            inputAge:
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
                    {
                        Console.WriteLine("Возраст должен быть > 0");
                        goto inputAge;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат возраста!");
                    goto inputAge;
                }
            }
            people.ForEach((p) =>
            {
                Console.WriteLine(p.Description);
            });
            Console.ReadKey();
        }
    }
}
