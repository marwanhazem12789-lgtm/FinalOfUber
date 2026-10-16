using AutoMapper;
using FinalOfUber.DTOs.UserDTOs;
using FinalOfUber.Models;
using FinalOfUber.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalOfUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public UsersController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await _unitofwork.User.GetAll();
            var e = mapper.Map<List<GetAllUsers>>(t);
            return Ok(e);

        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Name)
        {
            var e = await _unitofwork.User.Search(Name);
            return Ok(e);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTOs dto)
        {
            var e = await _unitofwork.User.Login(dto);
            if(e== null)
            {
                return NotFound();
            }
            return Ok(e);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Create(RegisterDTOs dto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var r = mapper.Map<User>(dto);
            await _unitofwork.User.Add(r);
            await _unitofwork.Save();
            return Created("",r);
        }
    }
}
