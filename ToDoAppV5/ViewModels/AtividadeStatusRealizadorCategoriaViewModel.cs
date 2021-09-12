using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppV5.Models;

namespace ToDoAppV5.ViewModels
{
    public class AtividadeStatusRealizadorCategoriaViewModel
    {
      
        public List<Categoria> CategoriasLista { get; set; }
        public List<Realizador> RealizadoresLista { get; set; }
        public List<Status> StatusLista { get; set; }
        public int Id { get; set; }
        public string NomeAtividade { get; set; }
        public int IdCategoria { get; set; }
        public int IdStatus { get; set; }
        public int IdRealizador { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataRegistro { get; set; }

    }
}
