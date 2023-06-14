using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.DAL;
using StudentAPI.DTOs.Groups;
using StudentAPI.DTOs.Teachers;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public TeacherController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public ActionResult<List<TeacherGetAllItems>> GetAll () 
        {
            var data = _context.Teachers.Include(x=>x.Groups).Select(x => new TeacherGetAllItems { Id = x.Id, FullName = x.FullName, GroupCount = x.Groups.Count });
            return StatusCode(200, data);
        }
        [HttpGet("{id}")]
        public ActionResult<TeacherGetDTO> GetDetail(int id)
        {
            IQueryable<Teacher> query = _context.Teachers.Include(x=>x.Groups).ThenInclude(x=>x.Group).ThenInclude(x=>x.Students).Where(x=>x.Id==id);
            if (query.Count() == 0)
            {
                ModelState.AddModelError("Id", "Teacher not found");
                  return BadRequest(ModelState);
            }

            Teacher teacher = query.FirstOrDefault();


            TeacherGetDTO teacherGetDTO = new TeacherGetDTO()
            {
                FullName = teacher.FullName,
                Id = teacher.Id,
                Groups=teacher.Groups.Select(x=>new GroupInTeacher {
                    
                    Id=x.Group.Id,
                    Name=x.Group.Name,
                    Students=x.Group.Students.Select(x=>new StudenInGroup {Id=x.Id,FullName=x.FullName }).ToList(),
                }).ToList()
            };

            return Ok(teacherGetDTO);



        }

        [HttpPost("")]
        public ActionResult<Teacher> Create(TeacherPostDTO teacherPostDTO)
        {
            
            Teacher teacher = new Teacher()
            {
                  FullName=teacherPostDTO.Name,
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
           
            return Ok(200);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id,TeacherPutDTO teacherPutDTO)
        {

            Teacher existteacher=_context.Teachers.Include(x=>x.Groups).FirstOrDefault(x=>x.Id==id);
            if (existteacher == null)
            {
                return NotFound();
            }
           
            existteacher.FullName = teacherPutDTO.Name;

            _context.SaveChanges();
            return StatusCode(200);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Teacher teacher=_context.Teachers.FirstOrDefault(x=>x.Id== id);
            if(teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher); 
            _context.SaveChanges();
            return NoContent();


        }

    }
}
