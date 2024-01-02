using Dapper;
using student.Infrastructure.Context;
using Student.Domain.Interface;
using System.Data;
using Student.Domain.Models;
using Student.Domain.Service;
using Microsoft.Azure.Amqp.Framing;

namespace Student.Infrastructure.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        #region Constructor
        private readonly StudentContext _studentContext;
        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        #endregion
        #region Repository layer for getting the student details
        public async Task<List<Students>> GetAllAsync()
        {
            var storedProcedure = "usp_GetAllStudents";
                using (var connection = _studentContext.CreateConnection())
                {
                    var students = (await connection.QueryAsync<Students>(storedProcedure, commandType: CommandType.StoredProcedure)).ToList();
                    return students;                
                }
        }
        #endregion
        #region Repository layer for adding a student
        public async Task<string> AddAsync(Students student)
        {
            string response = string.Empty;
            var storedProcedure = "usp_PostStudents";
            var parameters = new DynamicParameters();
            parameters.Add("id", student.Id);
            parameters.Add("studentName", student.StudentName);
            using (var connection = _studentContext.CreateConnection())
            {
                var result = await connection.QueryAsync<bool>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                response = "Student Added";
            }
            return response;
        }
        #endregion
        #region Repository layer for Updating an existing student name
        public async Task<string> UpdateAsync(Students student)
        {
            var response = string.Empty;
            var storedProcedure = "usp_UpdateStudent";
            var parameters = new DynamicParameters();
            parameters.Add("id", student.Id);
            parameters.Add("studentName", student.StudentName);
            using(var connection = _studentContext.CreateConnection())
            {
                var update=await connection.QueryAsync<bool>(storedProcedure, parameters,commandType: CommandType.StoredProcedure);
                response = "Student name Updated";
            }
            return response;
        }
        #endregion
        #region Repository layer for deleting a student by passing an id
        public async Task<string> DeleteAsync(int id)
        {
            var response = string.Empty;
            var storedProcedure = "usp_DeleteStudent";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using(var connection= _studentContext.CreateConnection())
            {
                var delete= await connection.QueryAsync<bool>(storedProcedure, parameters,commandType:CommandType.StoredProcedure);
                response = "Student Deleted";
            }
            return response;
        }
        #endregion
    }
}
