using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Department
    {
        private string name;
        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        public bool HasFreeBed()
        {
            return this.Rooms.Sum(x => x.Beds.Count) < 60;
        }
    }
}
