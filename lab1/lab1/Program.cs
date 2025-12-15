namespace lab1;

public class Program
{
    static void Main()
    {
        var system = new CourseSystem();

        var course1 = new OfflineCourse(1, "Курс по ООП", "Курс нацелен на ...", "A101", "каждый вторник в 15:00", 100);
        var course2 = new OnlineCourse(2, "Курс по Алгосам", "WW курс", "Stepik", "stepik.com");
        var course3 = new OnlineCourse(3, "Курс по завязыванию шнурков", "Круто курс по ...", "Rutube", "rutube.ru");

        var teacher1 = new Teacher(1, "Ivan", "Ivanov", 45, "petrov@yandex.ru");
        var teacher2 = new Teacher(2, "Petr", "Petrov", 57, "ivanov@yandex.ru");

        var student1 = new Student(1, "Max", "Maximov", 20, "maximka@mail.ru");
        var student2 = new Student(2, "Leon", "Kanevsky", 19, "leonid@mail.ru");
        var student3 = new Student(3, "Nikita", "Bumagov", 45, "nikit@mail.ru");
        
        system.AddCourse(course1);
        system.AddCourse(course2);
        system.AddCourse(course3);
        
        system.AddTeacher(teacher1);
        system.AddTeacher(teacher2);
        system.AddStudent(student1);
        system.AddStudent(student2);
        system.AddStudent(student3);
        
        system.AddTeacherToCourse(1, 1);
        system.AddTeacherToCourse(2, 2);
        system.AddStudentToCourse(1, 1);
        system.AddStudentToCourse(2, 1);
        system.AddStudentToCourse(3, 2);
        system.AddStudentToCourse(2, 3);
        
        Console.WriteLine(system.GetCourseInfo(1) + "\n");
        Console.WriteLine(system.GetCourseInfo(2) + "\n");
        Console.WriteLine(system.GetCourseInfo(3) + "\n");
    }
}
