using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppV5.Models;

namespace ToDoAppV5.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options ) : base(options)
        {

        }
        public DbSet<Realizador> Realizadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Status> Status { get; set; }

    }
}
