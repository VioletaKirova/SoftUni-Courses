using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_OpinionPoll
{
    public class Group
    {
        private List<Person> people;

        public Group()
        {
            this.people = new List<Person>();
        }

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new Exception();
            }

            this.people.Add(person);
        }

        public List<Person> FilterGroup()
        {
            return this.people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        }
    }
}
