using System;
using AutoMapper;
using ToDo_List_App.Model;
using ToDo_List_App.ViewModel;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Todo, TodoAddViewModel>().ReverseMap();
        CreateMap<Todo, TodoUpdateViewModel>().ReverseMap();
    }
}
