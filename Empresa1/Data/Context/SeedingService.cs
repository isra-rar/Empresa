using Empresa1.Data.Context;
using System.Linq;



public class SeedingService
{
    private EmpresaContext _context;

    public SeedingService(EmpresaContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Funcionarios.Any() ||
            _context.Departamentos.Any())
        {
            return; //DB has been seeded
        }

        _context.SaveChanges();
    }
}
