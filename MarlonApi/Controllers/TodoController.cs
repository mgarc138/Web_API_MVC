using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarlonApi.Models;
using System.Linq;

namespace MarlonApi.Controllers
{
    //[Route("api/[[todo]]")]
    [Route("api/student")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context){

            _context = context;

            if(_context.TodoItems.Count()==0){
                _context.TodoItems.Add(new TodoStudent { Name = "Marlon Garcia", Address = "10322 addison ave franklin park", Email = "marlon@gmail.com", PhoneNumber = "773-890-1234", BSEducationSchool = "Depaul University" , BSEducationTitle = "Computer Science", WorkExperienceCompanyNameOne = "FaceBook", WorkExperienceTitleOne = "Developer", ExtraCurricularActivitiesOne = "Programming" });
                _context.SaveChanges();
            }

        }


[HttpPost]
public IActionResult Create([FromBody] TodoStudent item)
{
    if (item == null)
    {
        return BadRequest();
    }

    _context.TodoItems.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
}



        [HttpGet]
        public IEnumerable<TodoStudent> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if(item == null){
                
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
public IActionResult Update(long id, [FromBody] TodoStudent item)
{
    if (item == null || item.Id != id)
    {
        return BadRequest();
    }

    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
    if (todo == null)
    {
        return NotFound();
    }

    todo.Name = item.Name;
    todo.Address = item.Address;
    todo.Email = item.Email;
    todo.PhoneNumber = item.PhoneNumber;
    todo.BSEducationSchool = item.BSEducationSchool;
    todo.BSEducationTitle = item.BSEducationTitle;
    todo.MSEducationSchool = item.MSEducationSchool;
    todo.MSEducationTitle = item.MSEducationTitle;
    todo.PHdEducationSchool = item.PHdEducationSchool;
    todo.PHdEducationTitle = item.PHdEducationTitle;
    todo.WorkExperienceCompanyNameOne = item.WorkExperienceCompanyNameOne;
    todo.WorkExperienceTitleOne = item.WorkExperienceTitleOne;
    todo.WorkExperienceCompanyNameTwo = item.WorkExperienceCompanyNameTwo;
    todo.WorkExperienceTitleTwo = item.WorkExperienceTitleTwo;
    todo.WorkExperienceCompanyNameThree = item.WorkExperienceCompanyNameThree;
    todo.WorkExperienceTitleThree = item.WorkExperienceTitleThree;
    todo.ExtraCurricularActivitiesOne = item.ExtraCurricularActivitiesOne;
    todo.ExtraCurricularActivitiesTwo = item.ExtraCurricularActivitiesTwo;

    _context.TodoItems.Update(todo);
    _context.SaveChanges();
    return new NoContentResult();
}

[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
    if (todo == null)
    {
        return NotFound();
    }

    _context.TodoItems.Remove(todo);
    _context.SaveChanges();
    return new NoContentResult();
}


    }
}