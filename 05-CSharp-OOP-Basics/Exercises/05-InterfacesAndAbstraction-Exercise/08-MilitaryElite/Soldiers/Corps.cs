using _08_MilitaryElite.Contracts;
using System;

namespace _08_MilitaryElite.Soldiers
{
    public class Corps : ICorps
    {
        private string corpsType;

        public Corps()
        {

        }

        public Corps(string corpsType)
        {
            this.CorpsType = corpsType;
        }

        public string CorpsType
        {
            get { return corpsType; }
            set
            {
                if (value.ToLower() != "marines" && value.ToLower() != "airforces")
                {
                    throw new ArgumentException();
                }

                corpsType = value;
            }
        }

        public override string ToString()
        {
            return this.CorpsType;
        }
    }
}
