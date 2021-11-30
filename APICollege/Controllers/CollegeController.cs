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
    [Route("api/College")]
    public class CollegeController : Controller
    {
        private readonly CollegeService collegeSerice;

        public CollegeController(CollegeService collegeSerice)
        {
            this.collegeSerice = collegeSerice;
        }

        [HttpPost]
        public async Task<ActionResult> AddCollege(CollegeDTO college)
        {
            return Ok(await collegeSerice.AddAsync(college));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCollege()
        {
            return Ok(await collegeSerice.GetAllAsync());
        }

        [HttpGet("GetAllCollegeDTO")]
        public async Task<ActionResult> GetAllCollegeDTO()
        {
            return Ok(await collegeSerice.GetAllCollege());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCollegeById(int id)
        {
            return Ok(await collegeSerice.GetAsyncById(id));
        }


        [HttpGet("{id}/GetAsyncCollegeById")]
        public async Task<ActionResult> GetAsyncCollegeById(int id)
        {
            return Ok(await collegeSerice.GetAsyncCollegeById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollege(int id)
        {
            await collegeSerice.DeleteAsync(id);
            return Ok();
        }

    }
}
