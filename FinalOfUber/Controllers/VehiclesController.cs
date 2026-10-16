using AutoMapper;
using FinalOfUber.DTOs.Vehicle;
using FinalOfUber.Models;
using FinalOfUber.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalOfUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public VehiclesController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CreateAndUpdateVehicle dto)
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
            var r = mapper.Map<Vehicle>(dto);
            await _unitofwork.Vehicle.Add(r);
            await _unitofwork.Save();
            return Created("", r);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, CreateAndUpdateVehicle dto)
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
            var y = await _unitofwork.Vehicle.GetById(id);
            if (y == null)
            {
                return NotFound();
            }
            var r = mapper.Map(dto, y);
            _unitofwork.Vehicle.Update(r);
            await _unitofwork.Save();
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _unitofwork.Vehicle.GetById(id);
            if (e == null)
            {
                return NotFound();
            }

            _unitofwork.Vehicle.Remove(e);
            await _unitofwork.Save();
            return NoContent();
        }
    }
}
