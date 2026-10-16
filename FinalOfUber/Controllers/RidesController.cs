using AutoMapper;
using FinalOfUber.DTOs.RideDTOs;
using FinalOfUber.DTOs.Vehicle;
using FinalOfUber.Models;
using FinalOfUber.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalOfUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public RidesController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRide dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var e = await _unitofwork.User.GetById(dto.DriverId);
            if (e == null)
            {
                return NotFound();
            }
            var ee = await _unitofwork.User.GetById(dto.RiderId);
            if (ee == null)
            {
                return NotFound();
            }
            var r = mapper.Map<Ride>(dto);
            await _unitofwork.Ride.Add(r);
            await _unitofwork.Save();
            return Created();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _unitofwork.Ride.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            var e = mapper.Map<GetAllRides>(t);
            return Ok(e);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ToAccept(int id)
        {
            var e = await _unitofwork.Ride.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            e.Status = "Accept";
            _unitofwork.Ride.Update(e);
            await _unitofwork.Save();
            return NoContent();
        }
        [HttpPatch("{id}/Complete")]
        public async Task<IActionResult> ToComplete(int id)
        {
            var e = await _unitofwork.Ride.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            e.Status = "Complete";
            _unitofwork.Ride.Update(e);
            await _unitofwork.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _unitofwork.Ride.GetById(id);
            if (e == null)
            {
                return NotFound();
            }

            _unitofwork.Ride.Remove(e);
            await _unitofwork.Save();
            return NoContent();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Name)
        {
            var t = await _unitofwork.Ride.Search(Name);
            return Ok(t);
        }
        [HttpGet("Paginaion")]
        public async Task<IActionResult> Pgenation(int PageIndex, int pageSize, string SortBy)
        {
            var t =await _unitofwork.Ride.Paginaion(PageIndex, pageSize, SortBy);
            return Ok(t);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(string Status, int MinFare, int MaxFare, string SortBy)
        {
            var e = await _unitofwork.Ride.Filter(Status, MinFare, MaxFare, SortBy);
            return Ok(e);
        }
    }
}
