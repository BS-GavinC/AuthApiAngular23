using BLL.Interfaces;
using DAL.Models;
using DAL.Models.DTO.User;
using DAL.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("register")]
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


        [HttpPost("login")]
        public ActionResult<string> Login(LoginDTO loginDto)
        {
            if (ModelState.IsValid)
            {
                string? jwt = _userService.Login(loginDto);

                if (!string.IsNullOrEmpty(jwt)) 
                {
                    return Ok(jwt);
                }

            }

            return BadRequest();
        }


        [HttpPatch("password/{id}")]
        public ActionResult<UserViewModel> ChangePassword(int id, ChangePasswordDTO changePasswordDto)
        {
            if (ModelState.IsValid) 
            { 
                UserViewModel? userViewModel = _userService.UpdatePassword(id, changePasswordDto);
                if (userViewModel is not null)
                {
                    return Ok(userViewModel);
                }

            }
            return BadRequest();
        }

        [HttpPatch("phone/{id}")]
        public ActionResult<UserViewModel> ChangePhoneNumber(int id, ChangePhoneNumberDTO changephoneDto)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? userViewModel = _userService.UpdatePhoneNumber(id, changephoneDto);
                if (userViewModel is not null)
                {
                    return Ok(userViewModel);
                }

            }
            return BadRequest();
        }

        [HttpPatch("data/{id}")]
        public ActionResult<UserViewModel> ChangeDatas(int id, ChangeDataDTO changedataDto)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? userViewModel = _userService.UpdateDatas(id, changedataDto);
                if (userViewModel is not null)
                {
                    return Ok(userViewModel);
                }

            }
            return BadRequest();
        }

        [HttpPatch("role/{id}")]
        public ActionResult<UserViewModel> ChangeRole(int id, ChangeRoleDTO changeroleDto)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? userViewModel = _userService.UpdateRole(id, changeroleDto);
                if (userViewModel is not null)
                {
                    return Ok(userViewModel);
                }

            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserViewModel> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? user = _userService.GetById(id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpGet("{email}")]
        public ActionResult<UserViewModel> GetByEmail(string email)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? user = _userService.GetByEmail(email);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            if (ModelState.IsValid)
            {
                return _userService.Delete(id) ? Ok() : BadRequest();
            }
            return BadRequest();
        }


    }
}
