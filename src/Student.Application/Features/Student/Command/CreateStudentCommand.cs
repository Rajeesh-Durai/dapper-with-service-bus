using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Features.Student.Command
{
    public class CreateStudentCommand:IRequest<string>
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
    }
}
