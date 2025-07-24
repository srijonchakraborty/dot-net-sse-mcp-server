using ModelContextProtocol.Server;
using ASPController.Controllers;
using ASPController.Model;
using System.ComponentModel;

namespace SSEStudentTool.Tools
{
    [McpServerToolType]
    public static class StudentTool
    {
        static readonly ILogger<StudentController> logger = LoggerFactory .Create(builder => builder.AddConsole()) .CreateLogger<StudentController>();
        static StudentController studentController = new StudentController(logger);

        [McpServerTool, Description("Gets all students")]
        public static List<Student> GetAllStudents() => studentController. GetAllStudents();

        [McpServerTool, Description("Gets a student by ID")]
        public static Student? GetStudentById(int id) => studentController.GetStudentById(id);

        [McpServerTool, Description("Gets students by major")]
        public static List<Student> GetStudentsByMajor(string major) => studentController.GetStudentsByMajor(major);

        [McpServerTool, Description("Gets students with GPA above specified value")]
        public static List<Student> GetStudentsWithGpaAbove(double minGpa) => studentController.GetStudentsWithGpaAbove(minGpa);

        [McpServerTool, Description("Adds a new student")]
        public static string AddStudent(int id, string firstName, string lastName,
            string dateOfBirth, string email, double gpa, string major)
        {
            return studentController.AddStudent(new ASPController.Dto.StudentDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Major = major,
                GPA = gpa,
                Email = email,
                Id = id,
                DateOfBirth = dateOfBirth
            });
        }

        [McpServerTool, Description("Gets student statistics")]
        public static Dictionary<string, object> GetStudentStatistics()
        {
            return studentController.GetStudentStatistics();
        }

        [McpServerTool, Description("Gets students with only specified fields")]
        public static List<Dictionary<string, object>> GetStudentsWithFields(List<string> fieldsToInclude)
        {
           return studentController.GetStudentsWithFields(fieldsToInclude);
        }
    }
}
