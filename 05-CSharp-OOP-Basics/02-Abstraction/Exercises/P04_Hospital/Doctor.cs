using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        private string name;
        private List<string> patients;

        public Doctor(string firstName, string lastName)
        {
            this.Name = firstName + " " + lastName;
            this.Patients = new List<string>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<string> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

    }
}
