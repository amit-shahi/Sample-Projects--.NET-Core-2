using System;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Todo, TodoAddViewModel>().ReverseMap();
        CreateMap<Todo, TodoUpdateViewModel>().ReverseMap();
    }
}
