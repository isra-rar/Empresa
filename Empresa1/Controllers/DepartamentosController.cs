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
    public class DepartamentosController : MainController
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IDepartamentoService _departamentoService;
        private readonly IMapper _mapper;

        public DepartamentosController(IDepartamentoRepository departamentoRepository, IMapper mapper
            , IDepartamentoService departamentoService)
        {
            _departamentoRepository = departamentoRepository;
            _departamentoService = departamentoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartamentoDTO>> GetAllDepartamentos()
        {
            var departamento = _mapper.Map<IEnumerable<DepartamentoDTO>>(await _departamentoRepository.GetAll());

            return departamento;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DepartamentoDTO>> GetById(Guid id)
        {
            var departamento = _mapper.Map<DepartamentoDTO>(await _departamentoRepository.GetById(id));

            if (departamento == null) return NotFound();

            return departamento;
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentoDTO>> AddDepartamento(DepartamentoDTO departamentoDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            var result = await _departamentoService.Add(departamento);

            if (!result) return BadRequest();

            return Ok(departamento);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DepartamentoDTO>> UpdateDepartamento(Guid id, DepartamentoDTO departamentoDTO)
        {
            if (id != departamentoDTO.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            var result = await _departamentoService.Update(departamento);

            if (!result) return BadRequest();

            return Ok(departamento);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DepartamentoDTO>> DeleteDepartamento(Guid id)
        {
            var departamento = _mapper.Map<DepartamentoDTO>(await _departamentoRepository.GetById(id));

            if (departamento == null) return NotFound();

            var result = await _departamentoService.Remove(id);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
