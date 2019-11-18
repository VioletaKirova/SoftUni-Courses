using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Mankind
{
    public abstract class Human
    {
        private const int MIN_FIRST_NAME_LEN = 4;
        private const int MIN_LAST_NAME_LEN = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected string FirstName
        {
            get { return firstName; }
            set
            {
                CheckFirstName(value);

                firstName = value;
            }
        }

        protected string LastName
        {
            get { return lastName; }
            set
            {
                CheckLastName(value);

                lastName = value;
            }
        }

        private void CheckLastName(string value)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < MIN_LAST_NAME_LEN)
            {
                throw new ArgumentException($"Expected length at least {MIN_LAST_NAME_LEN} symbols! Argument: lastName");
            }
        }

        private void CheckFirstName(string value)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < MIN_FIRST_NAME_LEN)
            {
                throw new ArgumentException($"Expected length at least {MIN_FIRST_NAME_LEN} symbols! Argument: firstName");
            }
        }
    }
}
