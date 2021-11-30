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
    [Route("api/Subject")]
    public class SubjectController : Controller
    {
        private readonly SubjectService subjectService;

        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject(SubjectDTO subject)
        {
            return Ok(await subjectService.AddAsync(subject));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSubject()
        {
            return Ok(await subjectService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            return Ok(await subjectService.GetAsyncById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            await subjectService.DeleteAsync(id);
            return Ok();
        }
    }
}
