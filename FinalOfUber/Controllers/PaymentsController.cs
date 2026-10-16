using AutoMapper;
using FinalOfUber.DTOs.PaymentDTOs;
using FinalOfUber.DTOs.RideDTOs;
using FinalOfUber.Models;
using FinalOfUber.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalOfUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public PaymentsController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePayment dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var e = await _unitofwork.Ride.GetById(dto.RideId);
            if (e == null)
            {
                return NotFound();
            }
            var r = mapper.Map<Payment>(dto);
            await _unitofwork.Payment.Add(r);
            await _unitofwork.Save();
            return Created();
        }
    }
}
