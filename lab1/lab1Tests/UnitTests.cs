using lab1;

namespace lab1Tests;

public class UnitTests
{
    [Fact]
    public void AddCourse()
    {
        var system = new CourseSystem();
        var course = new OnlineCourse(1, "OOP", "Learn OOP","Zoom", "zoom.com");
        
        
        system.AddCourse(course);


        var actualCourse = system.GetCourse(1);
        Assert.NotNull(actualCourse);
        Assert.Equal(course, actualCourse);
    }

    [Fact]
    public void RemoveCourse()
    {
        var system = new CourseSystem();
        var course = new OnlineCourse(1, "OOP", "Learn OOP","Zoom", "zoom.com");
        system.AddCourse(course);


        system.RemoveCourse(1);

        
        Assert.Null(system.GetCourse(1));
    }
    
    [Fact]
    public void AddTeacherToCourse()
    {
        var system = new CourseSystem();
        var teacher = new Teacher(1, "Ivan", "Ivanov", 35, "ivan@yandex.ru");
        var course = new OnlineCourse(1, "OOP", "Learn OOP","Zoom", "zoom.com");
       
        
        system.AddTeacher(teacher);
        system.AddCourse(course);
        system.AddTeacherToCourse(1, 1);


        Assert.Equal(teacher, course.Teacher);
        Assert.Contains(course, teacher.Courses);
    }

    [Fact]
    public void AddStudentToCourse() 
    {
        var system = new CourseSystem();
        var student = new Student(1, "Petr", "Petrov", 21, "petrov@mail.com");
        var course = new OnlineCourse(1, "OOP", "Learn OOP", "Zoom", "zoom.com");
        

        system.AddStudent(student); 
        system.AddCourse(course);
        system.AddStudentToCourse(1, 1);


        Assert.Contains(student, course.Students);
        Assert.Contains(course, student.Courses);
    }

    [Fact]
    public void GetCoursesOfTeacher()
    {
        var system = new CourseSystem();
        var teacher = new Teacher(1, "Ivan", "Ivanov", 35, "ivan@yandex.ru");
        var course1 = new OnlineCourse(1, "OOP", "Learn OOP", "Zoom", "zoom.com");
        var course2 = new OfflineCourse(2, "Algorithms", "Learn algorithms", "A101", "Пятница 14:00-16:00", 25);
            
        system.AddTeacher(teacher);
        system.AddCourse(course1);
        system.AddCourse(course2);
            
        system.AddTeacherToCourse(1, 1);
        system.AddTeacherToCourse(1, 2);
        
        var teacherCourses = teacher.Courses;
        
        
        Assert.Equal(2, teacherCourses.Count);
        Assert.Contains(course1, teacherCourses);
        Assert.Contains(course2, teacherCourses);
    }

    [Fact]
    public void OnlineCourse_GetCourseDetails()
    {
        var course = new OnlineCourse(1, "OOP", "Learn OOP","Zoom", "zoom.com");
        
        var details = course.GetCourseInfo();
        
        Assert.Contains("Онлайн курс - OOP", details);
        Assert.Contains("Платформа - Zoom", details);
        Assert.Contains("Ссылка на курс - zoom.com", details);
    }
}