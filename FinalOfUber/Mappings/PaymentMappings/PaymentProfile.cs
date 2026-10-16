using AutoMapper;
using FinalOfUber.DTOs.PaymentDTOs;
using FinalOfUber.Models;

namespace FinalOfUber.Mappings.PaymentMappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePayment, Payment>();
        }
    }
}
