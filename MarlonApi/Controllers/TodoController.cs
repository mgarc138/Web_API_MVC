using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarlonApi.Models;
using System.Linq;

namespace MarlonApi.Controllers
{
    //[Route("api/[[todo]]")]
    /// <summary>
    /// Controller creation
    /// </summary>
    [Produces("application/json")]
    [Route("api/student")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        /// <summary>
        /// creates the first student object
        /// </summary>
        public TodoController(TodoContext context){

            _context = context;

            if(_context.TodoItems.Count()==0){
                _context.TodoItems.Add(new TodoStudent { Name = "Marlon Garcia", Address = "10322 addison ave franklin park", Email = "marlon@gmail.com", PhoneNumber = "773-890-1234", BSEducationSchool = "Depaul University" , BSEducationTitle = "Computer Science", WorkExperienceCompanyNameOne = "FaceBook", WorkExperienceTitleOne = "Developer", ExtraCurricularActivitiesOne = "Programming" });
                _context.SaveChanges();
            }

        }

/// <summary>
/// Creates a new student 
/// </summary>
/// <remarks>
/// Sample request:
///
///     POST /student
///     {
///        "name": "Student 1",
///        "address": "address 1",
///        "email": " student@gmail.com",
///        "phoneNumber": "334-123-6789",
///        "bsEducationSchool": "Depaul University",
///        "bsEducationTitle": "Computer Science",
///        "msEducationSchool": "DePaul Univercity",
///        "msEducationTitle": "Game Programming",
///        "workExperienceCompanyNameOne": "Google",
///        "workExperienceTitleOne": "Software Developer",
///        "workExperienceCompanyNameTwo": "Facebook",
///        "workExperienceTitleTwo": "Software Developer Intern",
///        "extraCurricularActivitiesOne": " Computer Science Society"
///     }
///
/// </remarks>
/// <param name="item"></param>
/// <returns>A newly-created TodoStudent</returns>
/// <response code="201">Returns the newly-created student</response>
/// <response code="400">If the item is null</response> 
[HttpPost]
[ProducesResponseType(typeof(TodoStudent), 201)]
[ProducesResponseType(typeof(TodoStudent), 400)]
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

        /// <summary>
        /// Gets All Students Information
        /// </summary>
        [HttpGet]
        public IEnumerable<TodoStudent> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        
        /// <summary>
        /// Gets a specific Student information.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if(item == null){
                
                return NotFound();
            }

            return new ObjectResult(item);
        }


/// <summary>
/// Updates a specific Student.
/// </summary>
/// <param name="id"></param> 
/// <param name="item"></param>
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

/// <summary>
/// Deletes a specific Student.
/// </summary>
/// <param name="id"></param> 
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