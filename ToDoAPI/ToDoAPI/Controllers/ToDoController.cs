using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Context;
using ToDoAPI.Model;

namespace ToDoAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;
		public ToDoController(ApplicationDbContext DbContext)
		{
			_dbContext = DbContext;
		}
		//[HttpGet]
		//public IEnumerable<ToDo> Getall() {

		//	var todos = new List<ToDo>()
		//	{
		//		new ToDo{Id=1,Name="APi",Description="I have to stydy Api's well"},
		//		new ToDo{Id=2,Name="MVC",Description="I have to stydy mvc's well"},
		//		new ToDo{Id=3,Name="DAL",Description="I have to stydy DAL's well"},
		//		new ToDo{Id=4,Name="BLL",Description="I have to stydy BLL's well"},
		//		new ToDo{Id=5,Name="PL",Description="I have to stydy PL's well"}

		//	};
		//	return todos;
		//}

		//==========================To get all ================================
		[HttpGet]
		[ProducesResponseType(statusCode: 200)]
		[ProducesResponseType(statusCode: 404)]
		public ActionResult Getall()
		{
			var todos= _dbContext.todos.ToList();
			if (todos.Count>0) { 
				return Ok(todos);
			}
			return NotFound();
		}

		//==========================To get by id================================

		[HttpGet("id")]
		[ProducesResponseType(statusCode: 200)]
		[ProducesResponseType(statusCode: 404)]
		public ActionResult Get(int id) {

			if (id == 0)
			{ return BadRequest(); }
			var todo =_dbContext.todos.Find(id);
			if (todo is null)
			{
				return NotFound("Todo is not Found");
			}


				return Ok(todo);

		}

		//========================== Create action ================================
		[HttpPost]
		public ActionResult Ceate(ToDo todos)
		{
			if (ModelState.IsValid)
			{
				_dbContext.todos.Add(todos);
				_dbContext.SaveChanges();
				return Ok(todos);
			}
			return BadRequest();
		}

		//========================== Update action ================================

		//[HttpPut("{id}")]
		//public IActionResult UpdateToDoItem(int id, [FromBody] ToDo updatedToDo)
		//{
		//	var existingToDo = _dbContext.todos.Find(id);

		//	if (existingToDo == null)
		//	{
		//		return NotFound();
		//	}

		//	// Update properties of existingToDo with values from updatedToDo
		//	existingToDo.Name = updatedToDo.Name;
		//	existingToDo.Description = updatedToDo.Description;
		//	existingToDo.CreatedDate = updatedToDo.CreatedDate;

		//	_dbContext.SaveChanges();

		//	return Ok(existingToDo);
		//}

		//========================== Delete action =============================
		//[HttpDelete("{id}")]
		//public IActionResult DeleteToDoItem(int id)
		//{
		//	var toDoItem = _dbContext.todos.Find(id);

		//	if (toDoItem == null)
		//	{
		//		return NotFound();
		//	}

		//	_dbContext.todos.Remove(toDoItem);
		//	_dbContext.SaveChanges();

		//	return NoContent();
		//}



	}
}
