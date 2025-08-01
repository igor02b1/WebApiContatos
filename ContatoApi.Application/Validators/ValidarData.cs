using ContatoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Application.Validators
{
    public static class ValidarData
    {
        public static bool ValidacaoData(DateTime dataNascimento)
        {
            var dataHoje = DateTime.Now;

            return dataHoje > dataNascimento;          

        }
    }
}

