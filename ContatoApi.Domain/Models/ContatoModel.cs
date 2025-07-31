using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Domain.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataNascimento { get; set; }

        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
