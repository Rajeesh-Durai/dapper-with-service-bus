using MediatR;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Exception;
using Student.Application.Features.Student.Command;
using Student.Application.Features.Student.Query;
using Student.Application.View_Model;

namespace Student.API.Controllers
{
    public class StudentController:ControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region Get all student details
        [HttpGet("GetAllStudentDetails")]
        public async Task<ActionResult<StudentResponse>> GetAllStudent()
        {
            try
            {
                var query = new GetStudentsQuery();
                var student = await _mediator.Send(query);
                return Ok(student);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error in getting the list of student details: {ex.Message}");
                return NotFound(ex.Message);
            }
        }
        #endregion
        #region Add new Student
        [HttpPost("AddNewStudent")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentCommand student)
        {
            try
            {
                var result = await _mediator.Send(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddStudent: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region Update existing student name
        [HttpPut("UpdateExistingStudentName")]
        public async Task<IActionResult> UpdateExistingStudentName([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            try
            {
                var result = await _mediator.Send(updateStudentCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateExistingStudentName: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Delete a student by passing an id
        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<string>> DeleteStudent(int id)
        {
            try
            {
                var command = new DeleteStudentCommand() { StudentId=id};
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Error in DeleteStudent: {ex.Message}");
                return NotFound();
            }
        }
        #endregion
    }
}
