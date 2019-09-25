namespace _08_PetClinic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Clinic : IClinic, IEnumerable<Pet>, IComparable<Clinic>
    {
        private Pet[] rooms;

        public Clinic(string name, Pet[] rooms)
        {
            this.Name = name;
            this.Rooms = rooms;
        }

        public Pet[] Rooms
        {
            get
            {
                return rooms;
            }
            private set
            {
                if (value.Length % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                rooms = value;
            }
        }

        public string Name { get; private set; }

        public bool AddPet(Pet pet)
        {
            int centralIndex = this.rooms.Length / 2;

            if (this.rooms[centralIndex] == null)
            {
                this.rooms[centralIndex] = pet;
                return true;
            }

            int count = 1;

            while (centralIndex  - count >= 0 && centralIndex + count <= this.rooms.Length - 1)
            {
                if (this.rooms[centralIndex - count] == null)
                {
                    this.rooms[centralIndex - count] = pet;
                    return true;
                }
                else if (this.rooms[centralIndex + count] == null)
                {
                    this.rooms[centralIndex + count] = pet;
                    return true;
                }

                count++;
            }

            return false;
        }

        public bool Release()
        {
            int centralIndex = this.rooms.Length / 2;

            for (int i = centralIndex; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < centralIndex; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public void PrintRoom(int roomNumber)
        {
            int roomIndex = roomNumber - 1;

            if (this.rooms[roomIndex] == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(this.rooms[roomIndex]);
            }
        }

        public void PrintAllRooms()
        {
            foreach (var room in this)
            {
                if (room == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(room);
                }
            }
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            for (int i = 0; i < this.rooms.Length; i++)
            {
                yield return this.rooms[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(Clinic other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool HasEmptyRooms()
        {
            if (this.rooms.Any(r => r == null))
            {
                return true;
            }

            return false;
        }
    }
}
