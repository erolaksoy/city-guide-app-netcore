using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.Business.Tools.JwtTool;
using Study.SehirRehberi.Dto.Concrete.UserDtos;
using Study.SehirRehberi.Entitiy.Concrete;

namespace Study.SehirRehberi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService, IMapper mapper, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.UserExists(userRegisterDto.UserName) == false)
                {
                    var userToCreate = new User
                    {
                        UserName = userRegisterDto.UserName
                    };
                    var createdUser = await _authService.Register(userToCreate, userRegisterDto.PassWord);
                    return Created("", createdUser);
                }
                ModelState.AddModelError("", errorMessage: "Username is already taken");
            }
            return NotFound();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await _authService.Login(userLoginDto.UserName, userLoginDto.PassWord);
                if (loginUser == null)
                {
                    return Unauthorized();
                }
                return Created("", _jwtService.GenerateJwt(loginUser));

            }
            return NoContent();
        }
    }
}
