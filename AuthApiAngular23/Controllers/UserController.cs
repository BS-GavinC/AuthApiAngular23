using BLL.Interfaces;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiAngular23.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserViewModel> Register(CreateUserDto createDto)
        {

            if (ModelState.IsValid) 
            {
                UserViewModel? user = _userService.Create(createDto);

                if (user == null) {

                    return BadRequest();
                }

                return Ok(user);
            }

            return BadRequest();
            
        }


    }
}
