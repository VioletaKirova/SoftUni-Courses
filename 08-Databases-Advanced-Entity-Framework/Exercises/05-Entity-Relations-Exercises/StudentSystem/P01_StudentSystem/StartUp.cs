namespace P01_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Data.Models;
    using Data.Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (StudentSystemContext dbContext = new StudentSystemContext())
            {
                SeedCourses(dbContext, GenerateCourses());
                SeedResources(dbContext, GenerateResources(dbContext));
                SeedStudents(dbContext, GenerateStudents());
                SeedStudentCourses(dbContext, GenerateStudentCourses(dbContext));      
                SeedHomeworkSubmissions(dbContext, GenerateHomeworkSubmissions(dbContext));              
            }
        }

        private static void SeedHomeworkSubmissions(StudentSystemContext dbContext, List<Homework> homeworkSubmissions)
        {
            dbContext.AddRange(homeworkSubmissions);
            dbContext.SaveChanges();
        }

        private static List<Homework> GenerateHomeworkSubmissions(StudentSystemContext dbContext)
        {
            List<Homework> homeworkSubmissions = new List<Homework>();

            var students = dbContext.Students.ToList();
            var courses = dbContext.Courses.ToList();

            HashSet<string> studentCourseIds = new HashSet<string>();

            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int studentIndex = random.Next(0, students.Count - 1);
                int courseIndex = random.Next(0, courses.Count - 1);

                string studentCourseId = $"{students[studentIndex].StudentId} {courses[courseIndex].CourseId}";

                studentCourseIds.Add(studentCourseId);          
            }

            foreach (var studentCourseId in studentCourseIds)
            {
                var tokens = studentCourseId.Split(' ');

                var content = courses.FirstOrDefault(c => c.CourseId == int.Parse(tokens[1])).Name + " Exercises";

                Homework homeworkSubmission = new Homework
                {
                    Content = content,
                    ContentType = (ContentType)Enum.ToObject(typeof(ContentType), random.Next(1, 4)),
                    StudentId = int.Parse(tokens[0]),
                    CourseId = int.Parse(tokens[1])
                };

                homeworkSubmissions.Add(homeworkSubmission);
            }

            return homeworkSubmissions;
        }

        private static void SeedStudentCourses(StudentSystemContext dbContext, List<StudentCourse> studentCourses)
        {
            dbContext.AddRange(studentCourses);
            dbContext.SaveChanges();
        }

        private static List<StudentCourse> GenerateStudentCourses(StudentSystemContext dbContext)
        {
            List<StudentCourse> studentCourses = new List<StudentCourse>();

            var studentIds = dbContext.Students.Select(s => s.StudentId).ToList();
            var courseIds = dbContext.Courses.Select(c => c.CourseId).ToList();

            HashSet<string> studentCourseIds = new HashSet<string>();

            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int studentIdIndex = random.Next(0, studentIds.Count - 1);
                int courseIdIndex = random.Next(0, courseIds.Count - 1);

                string studentCourseId = $"{studentIds[studentIdIndex]} {courseIds[courseIdIndex]}";

                studentCourseIds.Add(studentCourseId);
            }

            foreach (var studentCourseId in studentCourseIds)
            {
                var tokens = studentCourseId.Split(' ');

                StudentCourse studentCourse = new StudentCourse
                {
                    StudentId = int.Parse(tokens[0]),
                    CourseId = int.Parse(tokens[1])
                };

                studentCourses.Add(studentCourse);
            }

            return studentCourses;
        }

        private static void SeedStudents(StudentSystemContext dbContext, List<Student> students)
        {
            dbContext.AddRange(students);
            dbContext.SaveChanges();
        }

        private static List<Student> GenerateStudents()
        {
            List<Student> students = new List<Student>();

            string[] firstNames =
            {
                    "Ana",
                    "Radoslava",
                    "Silviya",
                    "Mihaela",
                    "Violeta",
                    "Lidiya",
                    "Gergana",
                    "Denica",
                    "Nadejda",
                    "Ivelina",
                    "Iliyan",
                    "Filip",
                    "Grigor",
                    "Emanuil",
                    "Petko",
                    "Georgi",
                    "Ivailo",
                    "Ivan",
                    "Mihail",
                    "Dimitar"
            };

            string[] lastNames =
            {
                    "Iliev",
                    "Kirov",
                    "Ivanov",
                    "Staikov",
                    "Andonov",
                    "Dimitrov",
                    "Simeonov",
                    "Velizarov",
                    "Kuzmanov",
                    "Radev",
                    "Stoichev",
                    "Samuilov",
                    "Mihailov",
                    "Geogiev",
                    "Stoyanov",
                    "Iordanov",
                    "Krasimirov",
                    "Mechev",
                    "Totev",
                    "Terziev"
            };

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    string name = $"{firstName} {lastName}";

                    if (firstName.EndsWith('a'))
                    {
                        name += "a";
                    }

                    Student student = new Student
                    {
                        Name = name
                    };

                    students.Add(student);
                }
            }

            return students;
        }

        private static void SeedResources(StudentSystemContext dbContext, List<Resource> resources)
        {
            dbContext.AddRange(resources);
            dbContext.SaveChanges();
        }

        private static List<Resource> GenerateResources(StudentSystemContext dbContext)
        {
            List<Resource> resources = new List<Resource>();

            string[] specifications =
            {
                    "Introduction to",
                    "Lab",
                    "Exercises",
                    "Exam Preparation",
                    "Final Exam"
            };

            string[] languages =
            {
                    "C#",
                    "Java",
                    "JS",
                    "PHP",
                    "Python",
                    "C++",
                    "Ruby"
            };

            Random random = new Random();

            foreach (var specification in specifications)
            {
                foreach (var language in languages)
                {
                    string name = string.Empty;

                    if (specification == "Introduction to")
                    {
                        name = $"{specification} {language}";
                    }
                    else
                    {
                        name = $"{language} {specification}";
                    }

                    int resourceTypeValue = random.Next(1, 5);
                    ResourceType resourceType = (ResourceType)Enum.ToObject(typeof(ResourceType), resourceTypeValue);

                    string url = $"www.studentsystem.com/{language}/{name.Split(' ')[0]}/{resourceType.ToString()}";

                    List<int> courseIds = dbContext.Courses.Select(c => c.CourseId).ToList();
                    int idIndex = random.Next(0, courseIds.Count - 1);
                    var courseId = courseIds[idIndex];

                    Resource resource = new Resource
                    {
                        Name = name,
                        Url = url,
                        ResourceType = resourceType,
                        CourseId = courseId
                    };

                    resources.Add(resource);
                }
            }

            return resources;
        }

        private static void SeedCourses(StudentSystemContext dbContext, List<Course> courses)
        {
            dbContext.AddRange(courses);
            dbContext.SaveChanges();
        }

        private static List<Course> GenerateCourses()
        {
            List<Course> courses = new List<Course>();

            string[] modules =
            {
                    "C#",
                    "Java",
                    "JS",
                    "PHP",
                    "Python",
                    "C++",
                    "Ruby"
            };

            string[] courseTypes =
            {
                    "Basics",
                    "Fundamentals",
                    "Advanced"
            };

            foreach (var module in modules)
            {
                foreach (var courseType in courseTypes)
                {
                    Course course = new Course
                    {
                        Name = $"{module} {courseType}",
                        Price = 300
                    };

                    courses.Add(course);
                }
            }

            return courses;
        }
    }
}
