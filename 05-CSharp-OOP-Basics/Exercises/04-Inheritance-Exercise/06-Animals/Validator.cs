using _06_Animals.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals
{
    public static class Validator
    {
        public static void ValidateAnimalType(string animalType)
        {
            if (animalType != "cat" &&
                animalType != "dog" &&
                animalType != "frog" &&
                animalType != "kitten" &&
                animalType != "tomcat")
            {
                throw new InvalidInputException();
            }
        }

        public static void ValidateAnimalInfo(string[] input)
        {
            // Check for missing or extra parameter - input must have name, age and gender
            if (input.Length != 3)
            {
                throw new InvalidInputException();
            }

            // Check for invalid age
            int animalAge;

            var parseAnimaAge = int.TryParse(input[1], out animalAge);

            if (!parseAnimaAge || animalAge < 0)
            {
                throw new InvalidInputException();
            }

            // Check for invalid gender
            string animalGender = input[2].ToLower();

            if (animalGender != "male" && animalGender != "female")
            {
                throw new InvalidInputException();
            }
        }
    }
}
