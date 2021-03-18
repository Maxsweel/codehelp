using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAplication.Models
{

    public class Contexto : DbContext
    {
    
        // Caso não exista a tabela e/ou a database, iremos criar na hora
        public Contexto (DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Caso não exista a tabela ele irá criar
        public DbSet<Contato> Contato { get; set; }
    
    }
}
