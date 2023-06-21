using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMapper _mapper;
        public EmprestimoController(IEmprestimoRepository emprestimoRepository, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }
    }
}