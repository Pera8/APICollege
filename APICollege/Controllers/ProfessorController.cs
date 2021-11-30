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
    [Route("api/Professor")]
    public class ProfessorController : Controller
    {
        private readonly ProfessorService professorService;
        public ProfessorController(ProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpPost]
        public async Task<ActionResult> AddProfessor(ProfessorDTO professor)
        {
            return Ok(await professorService.AddAsync(professor));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProfessor()
        {
            return Ok(await professorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfessorById(int id)
        {
            return Ok(await professorService.GetAsyncById(id));
        }

        [HttpGet("{id}/GetAsyncProfessorDTOById")]
        public async Task<ActionResult> GetAsyncProfessorDTOById(int id)
        {
            return Ok(await professorService.GetAsyncProfessorDTOById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfessor(int id)
        {
            await professorService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("AddSubjectFromProfessor")]
        public async Task<ActionResult> AddSubjectFromProfessor(int professorId, int subjectId)
        {
            return Ok(await professorService.AddSubjectFromProfessor(professorId, subjectId));
        }

        [HttpPost("AddProfessorFromSubject")]
        public async Task<ActionResult> AddProfessorFromSubject(int professorId, int subjectId)
        {
            return Ok(await professorService.AddProfessorFromSubject(professorId, subjectId));
        }
    }
}
