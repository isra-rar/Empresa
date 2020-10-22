using AutoMapper;
using Empresa1.DTO;
using Empresa1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
        } 
    }
}
