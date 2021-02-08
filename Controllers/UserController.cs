using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SemearApi.Entities;
using SemearApi.Payload.request;
using SemearApi.Payload.response;
using SemearApi.Service;

namespace SemearApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :  ControllerBase
    {
        
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequest model)
        {
            var response = _userService.Authenticate(model.UserName, model.Password);
            
            if (response == null)
                return BadRequest(new { message = "Nome de usuario ou senha incorretos." });
           
            model.Token = response;
            
            return Ok(model);
        }
    
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest model)
        {
            if (_userService.VerifyExist(model.UserName))
            {
                return BadRequest(new { message = "Nome de usuario Ja existe" });
            }
            
            var response = await _userService.CreateUser(model.Convert(), model.learn.ToList(), model.instruct.ToList());
            
            if (response == 0)
                return BadRequest(new { message = "Erro ao cadastrar usuario" });
            model.Id = response;
            return   Ok(model);
        }
        
        //[Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user =  _userService.GetById(id);
            var model = new UserResponse(user);
            if (user == null)
                return NotFound();

            return Ok(model);
        }
        
        
        //para testar  Authorize remover apois o teste
        /*
        [Authorize(Roles = Role.Admin)]
        */
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            
            var userList = users.Select(s => new UserResponse(s)).ToList();
         
            return Ok(userList);
        }
        
        
        
        //para testar  Authorize remover apois o teste
        /*
        [Authorize(Roles = Role.Admin)]
        */
        
        [HttpGet("filter/{learnId}")]
        public IActionResult GetAll(int  learnId)
        {
            var users = _userService
                .GetAll()
                .Where(s =>s.UserLearn
                    .Select(sl =>sl.LearnId)
                    .Contains(learnId));
            
            var userList = users.Select(s => new UserResponse(s)).ToList();
         
            return Ok(userList);
        }

        
        
        
    }
}