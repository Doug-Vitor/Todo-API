using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Data.Context;

namespace TodoApi.Infrastructure.Data.Services
{
    public class SeedingServices
    {
        private readonly TodoContext _context;

        public SeedingServices(TodoContext context) => _context = context;

        public void SeedDatabase()
        {
            if (_context.Todos.Any()) return;

            List<Todo> todos = new()
            {
                new("Ir à academia", "Seus músculos não se desenvolverão sozinhos. Por favor, vá treinar!", false) { CreatedAt = DateTime.Now },
                new("Ir ao supermercado", "Nossa geladeira está vazia. Resolva isso!", false) { CreatedAt = DateTime.Now },
                new("Consulta médica (31/02)", "Já esqueceu que você tem problemas dermatológicos? Se cuide!", false) { CreatedAt = DateTime.Now },
                new("Praia com os colegas", "Sem desculpinhas dessa vez; divirta-se ao menos neste sábado!", false) { CreatedAt = DateTime.Now }
            };

            _context.AddRange(todos);
            _context.SaveChanges();
        }
    }
}
