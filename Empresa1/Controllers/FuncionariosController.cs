using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Empresa1.DTO;
using Empresa1.Interfaces;
using Empresa1.Models;
using Empresa1.Services.Interfaces;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Empresa1.Controllers
{
    [Route("api/[controller]")]
    public class FuncionariosController : MainController
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IMapper mapper
            ,IFuncionarioService funcionarioService)
        {
            _funcionarioRepository = funcionarioRepository;
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FuncionarioDTO>> GetAllFuncionarios()
        {
            var funcionario = _mapper.Map<IEnumerable<FuncionarioDTO>>(await _funcionarioRepository.GetAll());

            return funcionario;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FuncionarioDTO>> GetById(Guid id)
        {
            var funcionario = _mapper.Map<FuncionarioDTO>(await _funcionarioRepository.GetById(id));

            if (funcionario == null) return NotFound();

            return funcionario;
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioDTO>> AddFuncionario(FuncionarioDTO funcionarioDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);
            var result = await _funcionarioService.Add(funcionario);

            if (!result) return BadRequest();

            return Ok(funcionario);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FuncionarioDTO>> UpdateFuncionario(Guid id, FuncionarioDTO funcionarioDTO)
        {
            if (id != funcionarioDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);
            var result = await _funcionarioService.Update(funcionario);

            if (!result) return BadRequest();

            return Ok(funcionario);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FuncionarioDTO>> DeleteFuncionario(Guid id)
        {
            var funcinario = _mapper.Map<FuncionarioDTO>(await _funcionarioRepository.GetById(id));

            if (funcinario == null) return NotFound();

            var result = await _funcionarioService.Remove(id);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
