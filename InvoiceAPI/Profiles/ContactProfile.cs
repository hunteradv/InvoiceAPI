using AutoMapper;
using InvoiceAPI.Data.Dtos.Contact;
using InvoiceAPI.Models;

namespace InvoiceAPI.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, ReadContactDto>();
        }
    }
}
