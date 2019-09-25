using _08_MilitaryElite.Contracts;
using System;

namespace _08_MilitaryElite.Soldiers
{
    public class Mission : IMission
    {
        private string state;

        public Mission()
        {

        }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }

        public string State
        {
            get { return state; }
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException();
                }

                state = value;
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
