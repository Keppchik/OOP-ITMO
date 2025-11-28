namespace lab1;
 
public class OfflineCourse: Course
{
    public string Classroom { get; }
    public string Schedule { get; }
    public int Capacity { get; }

    public OfflineCourse(int id, string name, string description, string classroom, string schedule, int capacity) : base(id, name, description)
    {
        Classroom = classroom;
        Schedule = schedule;
        Capacity = capacity;
    }

    public override void AddStudent(Student student)
    {
        if (Students.Count < Capacity)
        {
            base.AddStudent(student);
        }
    }

    public override string GetCourseInfo()
    {
        return $"Курс - {Name}\n" +
               $"ID курса - {Id}\n" +
               $"Аудитория - {Classroom}\n" +
               $"Вместителность - {Capacity}\n" +
               $"Осталось мест - {Capacity - Students.Count}\n" +
               $"Студенты записанные на курс - {GetCourseStudents()}";
    }
}