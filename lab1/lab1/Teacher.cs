namespace lab1;

public class Teacher
{
    public int Id { get; }
    public string FisrtName { get; }
    public string SecondName { get; }
    public int Age { get; }
    public string Email { get; }
    public List<Course> Courses { get; }

    public Teacher(int id, string fisrtName, string secondName, int age, string email)
    {
        Id = id;
        FisrtName = fisrtName;
        SecondName = secondName;
        Age = age;
        Email = email;
        Courses = new List<Course>();
    }

    public string FullName => $"{FisrtName} {SecondName}";
    
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