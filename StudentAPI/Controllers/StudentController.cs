using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.DAL;
using StudentAPI.DTOs.Students;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public StudentController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

        var data = _context.Students.Include(x=>x.Group).FirstOrDefault(x=>x.Id==id);
            if (data == null) return StatusCode(404);
            var studenGetDTO= new StudenGetDTO()
            {   Id=id,
                FullName=data.FullName,
                AvgPoint=data.AvgPoint,
                Email=data.Email,
                Group=new GroupInStudentGetDTO()
                {
                    Id=data.GroupId,
                    Name=data.Group.Name,
                }
                
            };

            return StatusCode(200, studenGetDTO);
        }
        [HttpPost("")]
        public ActionResult Create(StudenPostDTO studentDTO)
        {
            if (!_context.Groups.Any(x => x.Id == studentDTO.GroupId))
            {
                ModelState.AddModelError("GroupId", "Group not found");
                return BadRequest(ModelState);
            }
            if (_context.Students.Any(x => x.Email == studentDTO.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return BadRequest(ModelState);
            }

            Student student = new Student()
            {
                FullName=studentDTO.FullName,
                Email=studentDTO.Email,
                AvgPoint = studentDTO.AvgPoint,
                GroupId=studentDTO.GroupId,
                

            };
            _context.Students.Add(student);
            _context.SaveChanges();

            return StatusCode(201,new {id=student.Id});
        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id,StudenPutDTO studentEditDTO )
        {
            Student existStudent=_context.Students.FirstOrDefault(x => x.Id == id);
            if(existStudent==null) return StatusCode(404);
            if (_context.Students.Any(x=>x.Email==studentEditDTO.Email) && studentEditDTO.Email!=existStudent.Email) 
            {
                ModelState.AddModelError("Email", "Email is already taken");
                return BadRequest(ModelState);

            }
            if (!_context.Groups.Any(x=>x.Id==studentEditDTO.GroupId))
            {
                ModelState.AddModelError("GroupId", "Group not found");
                return BadRequest(ModelState);
            }
            
            existStudent.FullName= studentEditDTO.FullName;
            existStudent.AvgPoint = studentEditDTO.AvgPoint;
            _context.SaveChanges();

            return StatusCode(200);
        }
    }

}
