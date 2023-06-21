using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        public AutorController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }
    }
}



//https://github.com/diegors-prog/Aulas-01-2023/blob/main/gestaoclick-api/WebApi/Controllers/ProdutoController.cs