using CashFlowApi.DTOs;
using CashFlowApi.Exceptions;
using CashFlowApi.Services;
using CashFlowApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowApi.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // GET: UserController/Details/5
        [HttpGet ("{id}")]
        public async Task <ActionResult<UserViewModel>> GetById ([FromRoute] int id)
        {
            var user = await _userService.GetById (id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: UserController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create ([FromBody]UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.Create(userDto);

            return Ok("User created");
        }

        // POST: UserController/Edit/5
        [HttpPut ("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] UserDto userDto)
        {
            try
            {
                await _userService.Update(id, userDto);
                return Ok("User updated");
            }
            catch (NotFoundException ex)
            { 
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);                
            }
        }

        // POST: UserController/Delete/5
        [HttpDelete ("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok("User deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
