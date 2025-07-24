# .NET SSE MCP Server - Student Information

A modern .NET 9.0 web API that implements the Model Context Protocol (MCP) server with Server-Sent Events (SSE) transport, providing a comprehensive student management system with both REST API endpoints and MCP tools.

## 🚀 Features

- **Model Context Protocol (MCP) Server**: Implements MCP specification for AI model integration
- **Server-Sent Events (SSE) Transport**: Real-time communication capabilities
- **REST API Endpoints**: Traditional HTTP endpoints for student management
- **Swagger/OpenAPI Documentation**: Interactive API documentation
- **Student Management**: Complete CRUD operations for student data
- **Advanced Queries**: Filter students by major, GPA, and custom fields
- **Statistics**: Generate comprehensive student statistics
- **Modern .NET 9.0**: Built with the latest .NET framework

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or VS Code
- Git

## 🛠️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/dot-net-sse-mcp-server.git
   cd dot-net-sse-mcp-server
   ```

2. **Navigate to the project directory**
   ```bash
   cd StudentWebAPIWithMCPServer
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

The application will start on `https://localhost:7000` (or the configured port in `launchSettings.json`).

## 📚 API Documentation

Once the application is running, you can access:
- **Swagger UI**: `https://localhost:7000/swagger`
- **OpenAPI JSON**: `https://localhost:7000/openapi.json`

## 🔧 MCP Tools

The server exposes the following MCP tools:

### Student Management Tools

| Tool | Description | Parameters |
|------|-------------|------------|
| `GetAllStudents` | Retrieves all students | None |
| `GetStudentById` | Gets a specific student by ID | `id` (int) |
| `GetStudentsByMajor` | Filters students by major | `major` (string) |
| `GetStudentsWithGpaAbove` | Gets students with GPA above threshold | `minGpa` (double) |
| `AddStudent` | Adds a new student | `id`, `firstName`, `lastName`, `dateOfBirth`, `email`, `gpa`, `major` |
| `GetStudentStatistics` | Returns comprehensive statistics | None |
| `GetStudentsWithFields` | Returns students with specified fields only | `fieldsToInclude` (List<string>) |

### Example MCP Tool Usage

```json
{
  "method": "tools/call",
  "params": {
    "name": "GetStudentsByMajor",
    "arguments": {
      "major": "Computer Science"
    }
  }
}
```

## 🌐 REST API Endpoints

### Student Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/Student/GetAllStudents` | Get all students |
| `POST` | `/Student/GetStudentById` | Get student by ID |
| `POST` | `/Student/GetStudentsByMajor` | Filter by major |
| `POST` | `/Student/GetStudentsWithGpaAbove` | Filter by minimum GPA |
| `POST` | `/Student/AddStudent` | Add new student |
| `POST` | `/Student/GetStudentStatistics` | Get statistics |
| `POST` | `/Student/GetStudentsWithFields` | Get students with specific fields |

### Example API Calls

#### Get All Students
```bash
curl -X POST "https://localhost:7000/Student/GetAllStudents" \
     -H "Content-Type: application/json"
```

#### Add New Student
```bash
curl -X POST "https://localhost:7000/Student/AddStudent" \
     -H "Content-Type: application/json" \
     -d '{
       "id": 7,
       "firstName": "Alice",
       "lastName": "Johnson",
       "dateOfBirth": "2002-04-15",
       "email": "alice.j@university.edu",
       "gpa": 3.85,
       "major": "Computer Science"
     }'
```

#### Get Students by Major
```bash
curl -X POST "https://localhost:7000/Student/GetStudentsByMajor" \
     -H "Content-Type: application/json" \
     -d '"Computer Science"'
```

## 📊 Student Model

```csharp
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public double GPA { get; set; }
    public string Major { get; set; }
}
```

## 🔍 Sample Data

The application comes with pre-loaded sample student data:

- John Doe (Computer Science, GPA: 3.75)
- Jane Smith (Mathematics, GPA: 3.92)
- Michael Johnson (Physics, GPA: 3.45)
- Emily Williams (Biology, GPA: 3.88)
- David Brown (Chemistry, GPA: 3.21)
- Srijon Chakraborty (Computer Science and Engineering, GPA: 3.21)

## 🏗️ Project Structure

```
StudentWebAPIWithMCPServer/
├── Controllers/
│   └── StudentController.cs          # REST API endpoints
├── Model/
│   └── Student.cs                    # Student entity and sample data
├── Dto/
│   └── StudentDto.cs                 # Data transfer objects
├── Tools/
│   └── StudentTool.cs                # MCP tools implementation
├── Program.cs                        # Application entry point
└── StudentWebAPIWithMCPServer.csproj # Project configuration
```

## 🛠️ Dependencies

- **.NET 9.0**: Latest .NET framework
- **ModelContextProtocol.AspNetCore**: MCP server implementation
- **Swashbuckle.AspNetCore**: Swagger/OpenAPI documentation
- **Microsoft.AspNetCore.OpenApi**: OpenAPI support

## 🚀 Development

### Running in Development Mode

```bash
dotnet run --environment Development
```

### Building for Production

```bash
dotnet build --configuration Release
dotnet publish --configuration Release
```
## Use MCP Server in VS Code Github Copilot
Add this config to settings of VS code
```
 "mcp": {
        "inputs": [],
        "servers": {
        "Srijon_Student_MCP": {
            "type": "stdio",
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "E:\\Personal Project\\mcptry\\MyFirstMCP\\MyFirstMCP.csproj"
            ]
        },
            "Student_MCP_Remote": {
            "type": "sse",
            "url":"http://mcpserversijon.runasp.net/sse",
            }
        }   
    }
```

### Run in remote server
<img width="893" height="728" alt="image" src="https://github.com/user-attachments/assets/0d8b2079-40c8-40ba-a77a-b2236194df66" />

### Run in local server from project
<img width="1297" height="723" alt="image" src="https://github.com/user-attachments/assets/ca135835-99f5-470b-896f-d6f328b96e71" />

### VS Code Detected the Tools
<img width="1658" height="860" alt="image" src="https://github.com/user-attachments/assets/4139eb5c-aeaf-413a-b672-81614d77bdeb" />

<img width="591" height="474" alt="image" src="https://github.com/user-attachments/assets/0cf035af-a4aa-4984-a362-45f97c89dd55" />

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- [Model Context Protocol](https://modelcontextprotocol.io/) for the MCP specification
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) for the web framework
- [Swagger](https://swagger.io/) for API documentation

## 📞 Support

If you have any questions or need support, please open an issue on GitHub or contact the maintainers.

---

**Note**: This is a demonstration project showcasing the integration of MCP servers with .NET web APIs. The student data is in-memory and will reset when the application restarts.
