namespace lab1;

public class OnlineCourse: Course
{
    public string Platform { get; }
    public string Url { get; }
    
    public OnlineCourse(int id, string name, string description, string platform, string url) : base(id, name, description)
    {
        Platform = platform;
        Url = url;
    }

    public override string GetCourseInfo()
    {
        return $"Онлайн курс - {Name}\n" +
               $"ID курса - {Id}\n" +
               $"Платформа - {Platform}\n" +
               $"Ссылка на курс - {Url}\n" +
               $"Прподаватель - {Teacher}\n" +
               $"Студенты записанные на курс - {GetCourseStudents()}";
    } 
}