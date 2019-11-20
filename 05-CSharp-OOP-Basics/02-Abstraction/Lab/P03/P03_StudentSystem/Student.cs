namespace P03_StudentSystem
{
    public class Student
    {
        private string name;
        private int age;
        private double grade;
          
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }
    }
}