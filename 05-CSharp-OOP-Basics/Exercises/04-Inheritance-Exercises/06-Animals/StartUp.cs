using System;

namespace _06_Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string animalType = Console.ReadLine();

                    if (animalType == "Beast!")
                    {
                        break;
                    }

                    string[] animalInfo = Console.ReadLine().
                        Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (animalInfo[0] == "Beast!")
                    {
                        break;
                    }

                    Validator.ValidateAnimalType(animalType.ToLower());
                    Validator.ValidateAnimalInfo(animalInfo);

                    string animalTypeStr = animalType.ToLower();

                    string animalName = animalInfo[0];
                    int animalAge = int.Parse(animalInfo[1]);
                    string animalGender = animalInfo[2];

                    switch (animalTypeStr)
                    {
                        case "cat":
                            Cat cat = new Cat(animalName, animalAge, animalGender);
                            Console.WriteLine(cat);
                            cat.ProduceSound();
                            break;
                        case "dog":
                            Dog dog = new Dog(animalName, animalAge, animalGender);
                            Console.WriteLine(dog);
                            dog.ProduceSound();
                            break;
                        case "frog":
                            Frog frog = new Frog(animalName, animalAge, animalGender);
                            Console.WriteLine(frog);
                            frog.ProduceSound();
                            break;
                        case "kitten":
                            Kitten kitten = new Kitten(animalName, animalAge);
                            Console.WriteLine(kitten);
                            kitten.ProduceSound();
                            break;
                        case "tomcat":
                            Tomcat tomcat = new Tomcat(animalName, animalAge);
                            Console.WriteLine(tomcat);
                            tomcat.ProduceSound();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
