using StudentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.DAL;

using StudentAPI.DTOs.Groups;
using StudentAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public GroupsController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public ActionResult<List<GroupAllItemDTO>> GetAll()
        {
            var data =_context.Groups.Include(x=>x.Students).Select(x=>new GroupAllItemDTO { Id=x.Id,Name=x.Name,StudenCount=x.Students.Count}).ToList();
            return Ok(data);
        }
        [HttpGet("")]
        public ActionResult<List<GroupAllItemDTO>> GetAll(int page=1)
        {
            var query=_context.Groups.AsQueryable();
            var items = query.Skip((page - 1) * 4).Take(4).Select(x => new GroupAllItemDTO { Id = x.Id, Name = x.Name,StudenCount=x.Students.Count }).ToList();
            var totalPages = (int)Math.Ceiling(query.Count() / 4d);
            var data = new PaginatedListDTO<GroupAllItemDTO>(items, totalPages, page);
            return Ok(data);
        }


        [HttpGet("{id}")]
        public ActionResult<Group> Get(int id) 
        { 
            var data = _context.Groups.Include(x=>x.Students).FirstOrDefault(x=>x.Id==id);
            if(data == null)
            {
                return StatusCode(404);
            }
            GroupGetDTO groupGetDTO = new GroupGetDTO
            {
                Id = data.Id,
                Name = data.Name,
                StudentInGroup = data.Students.Select(x => new StudentItemInGroupDTO { Id = x.Id, AvgPoint = x.AvgPoint, FullName = x.FullName, Email = x.Email }).ToList()
            };
            return Ok(groupGetDTO);
        }
        [HttpPost("")]
        public ActionResult Create(GroupPostDTO groupPostDTO)
        {
            if(_context.Groups.Any(x=>x.Name==groupPostDTO.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return BadRequest(ModelState);
            }
           Group group=new Group
           {
                 Name = groupPostDTO.Name
           };
            _context.Groups.Add(group);
            _context.SaveChanges();

            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id,GroupPutDTO groupPutDTO)
        {
            Group group = _context.Groups.FirstOrDefault(x => x.Id == id);
            if(group == null) return NotFound();
            if (group.Name!=groupPutDTO.Name && _context.Groups.Any(x=>x.Name==groupPutDTO.Name))
            {
                ModelState.AddModelError("Name", "This name is already used");
                return BadRequest(ModelState);
            }

            group.Name= groupPutDTO.Name;
            _context.SaveChanges();
            return StatusCode(200);
        }
        [HttpDelete("{id}")]
       public ActionResult Delete(int id)
        {
           Group group=_context.Groups.FirstOrDefault(x=>x.Id==id);
            if(group == null) return NotFound(); 
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return NoContent() ;
        }
    }
}
