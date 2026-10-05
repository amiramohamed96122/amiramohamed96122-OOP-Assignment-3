using src;

Store<Student> studentStore = new();

studentStore.Add(new Student(1, "Amira"));
studentStore.Add(new Student(2, "Aisha"));
studentStore.Add(new Student(3, "Aya"));
studentStore.Add(new Student(4, "Yassin"));
studentStore.Add(new Student(5, "Omar"));


Store<Course> courseStore = new();

courseStore.Add(new Course(1, "C# Basics", 100));
courseStore.Add(new Course(2, "OOP", 150));
courseStore.Add(new Course(3, "ASP.NET Core", 200));


// Get one Student by Id
Student? student = studentStore.GetById(1);
Console.WriteLine($"Student: {student?.Name}");

// Get one Course by Id
Course? course = courseStore.GetById(2);
Console.WriteLine($"Course: {course?.Title}");


// Try to add a duplicate Student Id
try
{
    studentStore.Add(new Student(1, "Duplicate Student"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}


// Print page 2 with page size 2
Console.WriteLine("Page 2:");

foreach (var studentItem in studentStore.GetAll().Page(2, 2))
{
    Console.WriteLine($"{studentItem.Id} - {studentItem.Name}");
}


// FindById on a plain List<Course>
List<Course> courses = new()
{
    new Course(1, "C# Basics", 100),
    new Course(2, "OOP", 150),
    new Course(3, "ASP.NET Core", 200)
};

Course? foundCourse = courses.FindById(2);

Console.WriteLine($"Found course: {foundCourse?.Title}");


// Must NOT compile
// new Store<string>(); // must NOT compile