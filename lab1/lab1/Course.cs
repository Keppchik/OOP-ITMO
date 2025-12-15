namespace lab1;

public abstract class Course
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<Student> Students { get; }
    public Teacher? Teacher { get; private set; }

    public Course(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
        Students = new List<Student>();
    }

    public void AddTeacher(Teacher teacher)
    {
        Teacher = teacher;
    }

    public void RemoveTeacher()
    {
        if (Teacher != null)
        {
            Teacher = null;
        }
    }

    public virtual void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (Students.Contains(student))
        {
            Students.Remove(student);
        }
    }
    
    protected string GetCourseStudents()
    {
        return string.Join(", ", Students.Select(student => student.FullName));
    }
    
    public abstract string GetCourseInfo();
}