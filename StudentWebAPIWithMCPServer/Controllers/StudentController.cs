using ASPController.Dto;
using ASPController.Model;
using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ASPController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GetStudentsByMajor")]
        public  List<Student> GetStudentsByMajor(string major) =>
           StudentsData.Students.Where(s => s.Major.Equals(major, StringComparison.OrdinalIgnoreCase)).ToList();

        [HttpPost("GetStudentsWithGpaAbove")]
        public List<Student> GetStudentsWithGpaAbove(double minGpa) =>
             StudentsData.Students.Where(s => s.GPA >= minGpa).ToList();

        [HttpPost("AddStudent")]
        public string AddStudent(StudentDto studentDto)
        {
            if (StudentsData.Students.Any(s => s.Id == studentDto.Id))
                return $"Student with ID {studentDto.Id} already exists";

            var dob = DateTime.Parse(studentDto.DateOfBirth);
            StudentsData.Students.Add(new Student(studentDto.Id, studentDto.FirstName, studentDto.LastName, dob, 
                                                  studentDto.Email, studentDto.GPA, studentDto.Major));
            return $"Student {studentDto.FirstName} {studentDto.LastName} added successfully";
        }
        
        [HttpPost("GetStudentStatistics")]
        public Dictionary<string, object> GetStudentStatistics()
        {
            return new Dictionary<string, object>
            {
                ["TotalStudents"] = StudentsData.Students.Count,
                ["AverageGPA"] = StudentsData.Students.Average(s => s.GPA),
                ["TopGPA"] = StudentsData.Students.Max(s => s.GPA),
                ["Majors"] = StudentsData.Students.GroupBy(s => s.Major)
                                    .ToDictionary(g => g.Key, g => g.Count())
            };
        }

        [HttpPost("GetStudentById")]
        public Student? GetStudentById(int id) => StudentsData.Students.FirstOrDefault(s => s.Id == id);

        [HttpPost("GetAllStudents")]
        public List<Student> GetAllStudents() => StudentsData.Students;

        [HttpPost("GetStudentsWithFields")]
        public List<Dictionary<string, object>> GetStudentsWithFields(List<string> fieldsToInclude)
        {
            var result = new List<Dictionary<string, object>>();

            foreach (var student in Model.StudentsData.Students)
            {
                var studentData = new Dictionary<string, object>();

                foreach (var field in fieldsToInclude)
                {
                    switch (field.ToLower())
                    {
                        case "id":
                            studentData["Id"] = student.Id;
                            break;
                        case "firstname":
                            studentData["FirstName"] = student.FirstName;
                            break;
                        case "lastname":
                            studentData["LastName"] = student.LastName;
                            break;
                        case "dateofbirth":
                            studentData["DateOfBirth"] = student.DateOfBirth.ToString("yyyy-MM-dd");
                            break;
                        case "email":
                            studentData["Email"] = student.Email;
                            break;
                        case "gpa":
                            studentData["GPA"] = student.GPA;
                            break;
                        case "major":
                            studentData["Major"] = student.Major;
                            break;
                        case "age":
                            studentData["Age"] = student.CalculateAge();
                            break;
                    }
                }

                result.Add(studentData);
            }
            return result;

        }
    }
}
