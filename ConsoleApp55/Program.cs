using System;
using System.Collections.Generic;

namespace GestionareAnimale
{
    interface IAnimal
    {
        string Cry();
        string Move();
    }

    class Dog : IAnimal
    {
        public string Cry()
        {
            return "Ham ham!";
        }

        public string Move()
        {
            return "Walking on four legs.";
        }
    }

    class Cat : IAnimal
    {
        public string Cry()
        {
            return "Meow!";
        }

        public string Move()
        {
            return "Jumping and running.";
        }
    }

    class Bird : IAnimal
    {
        public string Cry()
        {
            return "Tweet tweet!";
        }

        public string Move()
        {
            return "Flying in the sky.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add an animal");
                Console.WriteLine("2. Display all animals");
                Console.WriteLine("3. Search animal by sound");
                Console.WriteLine("4. Search animal by movement");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the type of animal (Dog/Cat/Bird):");
                        string animalType = Console.ReadLine();

                        IAnimal animal;
                        if (animalType.Equals("Dog", StringComparison.OrdinalIgnoreCase))
                        {
                            animal = new Dog();
                        }
                        else if (animalType.Equals("Cat", StringComparison.OrdinalIgnoreCase))
                        {
                            animal = new Cat();
                        }
                        else if (animalType.Equals("Bird", StringComparison.OrdinalIgnoreCase))
                        {
                            animal = new Bird();
                        }
                        else
                        {
                            Console.WriteLine("Invalid animal type. Animal not added.");
                            continue;
                        }

                        animals.Add(animal);
                        Console.WriteLine("Animal added successfully.");
                        break;

                    case "2":
                        Console.WriteLine("List of animals:");
                        foreach (var a in animals)
                        {
                            Console.WriteLine($"- Animal Type: {a.GetType().Name}");
                            Console.WriteLine($"  Sound: {a.Cry()}");
                            Console.WriteLine($"  Movement: {a.Move()}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter the sound to search for:");
                        string sound = Console.ReadLine();
                        bool found = false;

                        foreach (var a in animals)
                        {
                            if (a.Cry().Equals(sound, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"An animal that makes the sound '{sound}' exists.");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine($"No animal makes the sound '{sound}'.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter the movement to search for:");
                        string movement = Console.ReadLine();
                        found = false;

                        foreach (var a in animals)
                        {
                            if (a.Move().Equals(movement, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"An animal that moves '{movement}' exists.");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine($"No animal moves '{movement}'.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Exiting the application.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
