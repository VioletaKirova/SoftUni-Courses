using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals.Exceptions
{
    public class InvalidInputException : Exception
    {
        public override string Message => "Invalid input!";
    }
}
