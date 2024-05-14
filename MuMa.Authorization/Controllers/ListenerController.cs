using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using MuMa.Authorization.Dtos;
using MuMa.Domain.Repositories;
using MuMa.Domain.Listeners;

namespace MuMa.Authorization.Controllers
{
    [Route("/api/listener/")]
    public class ListenerController : ControllerBase
    {
        private readonly IListenerRepository _listenerRepository;
        private readonly IMapper _mapper;

        public ListenerController(IListenerRepository listenerRepository,
                                  IMapper mapper)
        {
            _listenerRepository = listenerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateListener(ListenerCreateDto listenerDto)
        {
            Listener listener = _mapper.Map<ListenerCreateDto, Listener>(listenerDto);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(listenerDto.Password);

            listener.Password = hashedPassword;
            await _listenerRepository.InsertAsync(listener);

            return Ok(_mapper.Map<Listener, ListenerDto>(listener));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listeners = await _listenerRepository.GetAll();
            return Ok(listeners);
        }
    }
}
