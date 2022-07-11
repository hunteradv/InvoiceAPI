using AutoMapper;
using InvoiceAPI.Data.Dtos.Clients;
using InvoiceAPI.Models;

namespace InvoiceAPI.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();
            CreateMap<Client, ReadClientDto>();
        }
    }
}
