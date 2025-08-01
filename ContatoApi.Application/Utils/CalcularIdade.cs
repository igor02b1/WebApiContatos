using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Application.Utils
{
    public class CalcularIdade
    {
        public static int CalcularContatoIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
        public static bool ContatoMaiorDeIdade(DateTime dataNascimento)
        {
            var resultadoIdade = CalcularContatoIdade(dataNascimento);

            return resultadoIdade >= 18;
        }
    }
}
