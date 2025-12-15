namespace lab1;

public class CourseSystem
{
    public List<Course> Courses { get; }
    public List<Teacher> Teachers { get; }
    public List<Student> Students { get; }

    public CourseSystem()
    {
        Courses = new List<Course>();
        Teachers = new List<Teacher>();
        Students = new List<Student>();
    }

    public void AddCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
        }
    }

    public void RemoveCourse(int CourseId)
    {
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (course != null)
        {
            course.RemoveTeacher();
            foreach (var student in course.Students)
            {
                course.RemoveStudent(student);
            }
            Courses.Remove(course);
        }
    }

    public void AddTeacher(Teacher teacher)
    {
        if (!Teachers.Contains(teacher))
        {
            Teachers.Add(teacher);
        }
    }

    public void RemoveTeacher(int TeacherId)
    {
        var teacher = Teachers.FirstOrDefault(teacher => teacher.Id == TeacherId);
        if (teacher != null)
        {
            foreach (var course in teacher.Courses)
            {
                course.RemoveTeacher();
            }
            Teachers.Remove(teacher);
        }
    }

    public void AddStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student); 
        }
    }

    public void RemoveStudent(int StudentId)
    {
        var student = Students.FirstOrDefault(student => student.Id == StudentId);
        if (student != null)
        {
            foreach (var course in student.Courses)
            {
                course.RemoveStudent(student);
            }
            Students.Remove(student);
        }
    }

    public void AddStudentToCourse(int StudentId, int CourseId)
    {
        var student =  Students.FirstOrDefault(student => student.Id == StudentId);
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (student != null && course != null)
        {
            student.AddCourse(course);
            course.AddStudent(student);
        }
    }

    public void RemoveStudentFromCourse(int StudentId, int CourseId)
    {
        var student = Students.FirstOrDefault(student => student.Id == StudentId);
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (student != null && course != null)
        { 
            student.RemoveCourse(course);
            course.RemoveStudent(student);
        }
    }
    
    public void AddTeacherToCourse(int TeacherId, int CourseId)
    {
        var teacher = Teachers.FirstOrDefault(teacher => teacher.Id == TeacherId);
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (teacher != null && course != null && course.Teacher == null)
        {
            teacher.AddCourse(course);
            course.AddTeacher(teacher);
        }
    }

    public void RemoveTeacherFromCourse(int CourseId)
    {
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (course != null && course.Teacher != null)
        {
            var teacher = course.Teacher;
            teacher.RemoveCourse(course);
            course.RemoveTeacher();
        }
    }

    public string GetCourseInfo(int CourseId)
    {
        var course = Courses.FirstOrDefault(course => course.Id == CourseId);
        if (course != null)
        {
            return course.GetCourseInfo();
        }
        return "Нет курса с таким ID";
    }

    public Course GetCourse(int CourseId)
    {
        return Courses.FirstOrDefault(course => course.Id == CourseId);
    }
    
    public Teacher GetTeacher(int TeacherId)
    {
        return Teachers.FirstOrDefault(course => course.Id == TeacherId);
    }
    
    public Student GetStudent(int StudentId)
    {
        return Students.FirstOrDefault(student => student.Id == StudentId);
    }
}