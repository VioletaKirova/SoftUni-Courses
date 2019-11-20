using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        private List<string> beds;

        public Room()
        {
            this.Beds = new List<string>();
        }

        public List<string> Beds
        {
            get { return beds; }
            set { beds = value; }
        }
    }
}
