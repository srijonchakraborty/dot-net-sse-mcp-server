namespace ASPController.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public double GPA { get; set; }

        public string Major { get; set; } = string.Empty;
    }
}
