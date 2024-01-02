using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Exception
{
    public class StudentNotFoundException : ApplicationException
    {
        public StudentNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
