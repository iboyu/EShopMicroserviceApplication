using AutoMapper;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Request;
using CustomerAPI.ApplicationCore.Models.Response;

namespace CustomerAPI
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Customer, CustomerRequestModel>().ReverseMap();
            CreateMap<Customer, CustomerResponseModel>().ReverseMap();

        }
        
    }
}
