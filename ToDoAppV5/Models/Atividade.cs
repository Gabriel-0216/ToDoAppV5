using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppV5.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string NomeAtividade { get; set; }
        public int IdCategoria { get; set; }
        public int IdStatus { get; set; }
        public int IdRealizador { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataRegistro { get; set; }


    }
}
