using System;

namespace P05_PizzaCalories
{
    public class Dough
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 200;

        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string bakingTechnique, double weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (value.ToLower() != "white" &&
                    value.ToLower() != "wholegrain")
                {
                    DoughException();
                }

                type = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    DoughException();
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    WeightException();
                }

                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            double typeModifier = 0.0;

            switch (Type.ToLower())
            {
                case "white":
                    typeModifier = 1.5;
                    break;

                case "wholegrain":
                    typeModifier = 1.0;
                    break;
            }

            double bakingTechniqueModifier = 0.0;

            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;

                case "chewy":
                    bakingTechniqueModifier = 1.1;
                    break;

                case "homemade":
                    bakingTechniqueModifier = 1.0;
                    break;
            }

            return (Weight * 2) * (typeModifier * bakingTechniqueModifier);
        }

        private static void DoughException()
        {
            throw new ArgumentException("Invalid type of dough.");
        }

        private static void WeightException()
        {
            throw new ArgumentException($"Dough weight should be in the range [{MIN_VALUE}..{MAX_VALUE}].");
        }
    }
}