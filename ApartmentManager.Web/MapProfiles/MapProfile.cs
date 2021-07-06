using ApartmentManager.Core.Models;
using ApartmentManager.Web.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<ListApartmentDto, Apartment>().ReverseMap();
            CreateMap<EditApartmentDto, Apartment>().ReverseMap();
            CreateMap<User, EditUserDto>().ReverseMap();
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<Expense, ListExpenseDto>().ReverseMap();
            CreateMap<Expense, EditExpenseDto>().ReverseMap();
            CreateMap<Apartment, DropdownApartmentDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, ListMessageDto>().ReverseMap();
            CreateMap<Apartment, ListApartmentWithExpenseDto>().ReverseMap();

        }
    }
}
