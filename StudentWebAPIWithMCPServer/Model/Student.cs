namespace ASPController.Model
{
    public class Student
    {
        // Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }

        // Constructor
        public Student(int id, string firstName, string lastName, DateTime dateOfBirth,
                      string email, double gpa, string major)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            GPA = gpa;
            Major = major;
        }

        // Method to display student information
        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} | DOB: {DateOfBirth:yyyy-MM-dd} | " +
                   $"Email: {Email} | GPA: {GPA:F2} | Major: {Major}";
        }

        // Method to calculate age
        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public static class StudentsData
    {
        public static List<Student> Students = new List<Student>
        {
            new Student(1, "John", "Doe", new DateTime(2000, 5, 15),
                "john.doe@university.edu", 3.75, "Computer Science"),
            new Student(2, "Jane", "Smith", new DateTime(1999, 8, 22),
                "jane.smith@university.edu", 3.92, "Mathematics"),
            new Student(3, "Michael", "Johnson", new DateTime(2001, 3, 10),
                "michael.j@university.edu", 3.45, "Physics"),
            new Student(4, "Emily", "Williams", new DateTime(2000, 11, 5),
                "emily.w@university.edu", 3.88, "Biology"),
            new Student(5, "David", "Brown", new DateTime(1999, 7, 30),
                "david.b@university.edu", 3.21, "Chemistry"),
            new Student(6, "Srijon", "Chakraborty", new DateTime(1994, 1, 1),
                "srijon.chakraborty@university.edu", 3.21, "Computer Science and Engineering")
        };

    }
}
