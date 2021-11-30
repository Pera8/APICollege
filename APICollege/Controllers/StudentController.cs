using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using Service;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICollege.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDTO student)
        {
            return Ok(await studentService.AddAsync(student));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStudent()
        {
            return Ok(await studentService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            return Ok(await studentService.GetAsyncById(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
           await studentService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetStudentsByPIdAndSId")]
        public async Task<ActionResult> GetStudentsByPIdAndSId(int subjectId, int studentId)
        {
            return Ok(await studentService.GetAllStudentByProfessorAndSubjectID(subjectId, studentId));
        }

        [HttpGet("GetSubjectsByIdProfessor")]
        public async Task<ActionResult> GetSubjectsByIdProfessor(int professorId)
        {
            return Ok(await studentService.GetSubjectsByIdProfessor(professorId));
        }
    }
}
