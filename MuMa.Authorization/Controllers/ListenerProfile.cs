using AutoMapper;
using MuMa.Authorization.Dtos;
using MuMa.Domain.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuMa.Authorization.Controllers
{
    public class ListenerProfile : Profile
    {
        public ListenerProfile()
        {
            CreateMap<ListenerCreateDto, Listener>();
            CreateMap<Listener, ListenerDto>();
        }
    }
}
