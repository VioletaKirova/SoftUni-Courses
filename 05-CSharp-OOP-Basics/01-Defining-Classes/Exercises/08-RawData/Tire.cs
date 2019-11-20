using System;
using System.Collections.Generic;
using System.Text;

namespace _08_RawData
{
    public class Tire
    {
        private int tireAge;
        private double tirePressure;

        public Tire(int tireAge, double tirePressure)
        {
            this.TireAge = tireAge;
            this.TirePressure = tirePressure;
        }

        public int TireAge
        {
            get { return this.tireAge; }
            set { this.tireAge = value; }
        }

        public double TirePressure
        {
            get { return this.tirePressure; }
            set { this.tirePressure = value; }
        }
    }
}
