using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpGet]

    public ActionResult<IEnumerable<User>> GetAllUsers() {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]

    public ActionResult<User?> GetUser(int id) {
        var user = _userService.GetUser(id);

        if(user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]

    public ActionResult<User> PostUser(User user) {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]

    public IActionResult PutUser(int id, User user) {
        if(id != user.Id)
            return BadRequest();

        _userService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteUser(int id) {
        _userService.DeleteUser(id);
        return NoContent();
    }
}