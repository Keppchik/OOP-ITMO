namespace lab1;

public class Student
{
    public int Id { get; }
    public string FirstName { get; }
    public string SecondName { get; }
    public int Age { get; }
    public string Email { get; }
    public List<Course> Courses { get; }

    public Student(int id, string firstName, string secondName, int age, string email)
    {
        Id = id;
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Email = email;
        Courses = new List<Course>();
    }
    
    public string FullName => $"{FirstName} {SecondName}";

    public void AddCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
        }
    }

    public void RemoveCourse(Course course)
    {
        Courses.Remove(course);
    }
}