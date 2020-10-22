using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Empresa1.DTO;
using Empresa1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Empresa1.Controllers
{
    [Route("api/[controller]")]
    public class FuncionariosController : MainController
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetAllFuncionarios()
        {
            var funcionario = _mapper.Map<IEnumerable<FuncionarioDTO>>(await _funcionarioRepository.GetAll());

            return funcionario;
        }
    }
}
